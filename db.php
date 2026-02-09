<?php

$host = "localhost";    // El servidor donde está la base de datos 
$port = "5432";         // Puerto por defecto de PostgreSQL 
$dbname = "concesionario"; // Nombre de tu base de datos 
$user = "postgres";     // Usuario con permisos 
$pass = "a";       // Contraseña del usuario 

try {
    
    $conectiondb = "pgsql:host=$host;port=$port;dbname=$dbname";
    $db = new PDO($conectiondb, $user, $pass);

    // Seguridad y Gestión de Errores
    $db->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);

    $sql = "CREATE TABLE IF NOT EXISTS vehiculos (
        id SERIAL PRIMARY KEY, -- SERIAL es el equivalente a Autoincremental en PostgreSQL
        nombre VARCHAR(255) NOT NULL,
        combustible VARCHAR(50) NOT NULL,
        stock INTEGER NOT NULL,
        imagen TEXT NOT NULL
    )";
    
    // Ejecutamos la creación de la tabla de forma directa
    $db->exec($sql);

} catch (PDOException $e) {
    
    echo "Error de conexión al SGBD: " . $e->getMessage();
    exit;
}
?>