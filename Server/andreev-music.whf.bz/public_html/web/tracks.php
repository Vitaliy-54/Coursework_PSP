<?php
$musicFolder = __DIR__ . '/../music/';

$files = array_filter(scandir($musicFolder), function($file) {
    return $file !== '.' && $file !== '..' && pathinfo($file, PATHINFO_EXTENSION) === 'mp3';
});

$tracks = [];
foreach ($files as $file) {
    $tracks[] = [
        'name' => pathinfo($file, PATHINFO_FILENAME),
        'file' => '../music/' . $file // Добавлен относительный путь к файлам
    ];
}

header('Content-Type: application/json; charset=UTF-8');
echo json_encode($tracks, JSON_UNESCAPED_UNICODE);
?>