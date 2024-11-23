<?php
$logFile = 'server.log';

if (file_exists($logFile)) {
    $logs = file_get_contents($logFile);
    $logEntries = explode("\n\n", $logs); // Разделение логов по блокам

    $startDate = isset($_GET['start']) ? $_GET['start'] : '';
    $endDate = isset($_GET['end']) ? $_GET['end'] : '';

    $filteredLogs = array_filter($logEntries, function($entry) use ($startDate, $endDate) {
        preg_match('/\[(.*?)\]/', $entry, $matches);
        if (isset($matches[1])) {
            $logDate = substr($matches[1], 0, 10);
            return $logDate >= $startDate && $logDate <= $endDate;
        }
        return false;
    });

    echo implode("\n\n", $filteredLogs);
} else {
    echo "Лог-файл не найден.";
}
?>
