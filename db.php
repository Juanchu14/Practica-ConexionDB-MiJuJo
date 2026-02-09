<?php
try {
    $archivo_db = "concesionario.sqlite";
    $db = new PDO("sqlite:" . $archivo_db);
    $db->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);

    
    $sql = "CREATE TABLE IF NOT EXISTS vehiculos (
        id INTEGER PRIMARY KEY AUTOINCREMENT,
        nombre TEXT NOT NULL,
        stock INTEGER NOT NULL,
        imagen TEXT NOT NULL
    )";
    
    $db->exec($sql);

    } catch (PDOException $e) {
    echo "Error con SQLite: " . $e->getMessage();
    exit;
}
?>