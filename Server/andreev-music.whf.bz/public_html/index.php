<?php
require_once __DIR__ . '/getID3-1.9.23/getid3/getid3.php';

$musicFolder = __DIR__ . '/music/';
$logFile = __DIR__ . '/server.log';
$baseUrl = 'http://andreev-music.whf.bz/music/';

date_default_timezone_set('Europe/Minsk'); // Установка часового пояса

function logMessage($message) {
    global $logFile;
    $timestamp = date('d-m-Y H:i:s'); // формат даты день-месяц-год
    error_log("[$timestamp] $message\n", 3, $logFile);
}

function getClientInfo() {
    $ip = $_SERVER['REMOTE_ADDR'];
    $clientData = getClientLocation($ip);
    $country = $clientData['country'] ?? 'Unknown';
    $region = $clientData['regionName'] ?? 'Unknown';
    $city = $clientData['city'] ?? 'Unknown';
    $isp = $clientData['isp'] ?? 'Unknown';
    return "IP: $ip, Country: $country, Region: $region, City: $city, ISP: $isp";
}

function getClientLocation($ip) {
    $url = "http://ip-api.com/json/$ip";
    $response = file_get_contents($url);
    return json_decode($response, true);
}

function getAllSongs() {
    global $musicFolder, $baseUrl;
    logMessage("Fetching all songs");
    $files = array_filter(scandir($musicFolder), function($file) {
        return $file !== '.' && $file !== '..' && pathinfo($file, PATHINFO_EXTENSION) === 'mp3';
    });

    $songs = [];
    foreach ($files as $file) {
        $filePath = $musicFolder . $file;
        $getID3 = new getID3();
        $fileInfo = $getID3->analyze($filePath);
        $songs[] = [
            'name' => $fileInfo['tags']['id3v2']['title'][0] ?? $file,
            'artist' => $fileInfo['tags']['id3v2']['artist'][0] ?? 'Unknown Artist',
            'path' => $baseUrl . $file,
            'duration' => $fileInfo['playtime_seconds']
        ];
    }

    logMessage("Fetched " . count($songs) . " songs");
    return $songs;
}

function streamAudio($filePath) {
    if (file_exists($filePath)) {
        logMessage("Streaming file: $filePath");

        $size = filesize($filePath);
        $start = 0;
        $length = $size;
        $end = $size - 1;

        if (isset($_SERVER['HTTP_RANGE'])) {
            $range = $_SERVER['HTTP_RANGE'];
            $range = str_replace('bytes=', '', $range);
            $range = explode('-', $range);
            $start = intval($range[0]);
            if (isset($range[1])) {
                $end = intval($range[1]);
            }
            $length = $end - $start + 1;
        }

        header('Content-Type: audio/mpeg');
        header('Accept-Ranges: bytes');
        header("Content-Range: bytes $start-$end/$size");
        header('Content-Length: ' . $length);

        $file = fopen($filePath, 'rb');
        fseek($file, $start);
        $bufferSize = 8192;
        while (!feof($file) && ($pos = ftell($file)) <= $end) {
            if ($pos + $bufferSize > $end) {
                $bufferSize = $end - $pos + 1;
            }
            set_time_limit(0);
            echo fread($file, $bufferSize);
            flush();
        }
        fclose($file);
    } else {
        logMessage("File not found: $filePath");
        http_response_code(404);
        echo json_encode(['error' => 'File not found']);
    }
}

$action = isset($_GET['action']) ? $_GET['action'] : 'list';

logMessage("Client connected: " . getClientInfo());

if ($action === 'list') {
    $songs = getAllSongs();
    $totalSongs = count($songs);

    header('Content-Type: application/json; charset=UTF-8');
    echo json_encode(['songs' => $songs, 'totalSongs' => $totalSongs], JSON_UNESCAPED_UNICODE);
} elseif ($action === 'play') {
    $fileName = isset($_GET['file']) ? $_GET['file'] : '';
    $filePath = $musicFolder . $fileName;
    streamAudio($filePath);
} else {
    logMessage("Invalid action: $action");
    echo "Invalid action.";
}

register_shutdown_function(function() {
    logMessage("Client disconnected: " . getClientInfo());
});
?>