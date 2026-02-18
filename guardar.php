<?php
include 'db.php'; 

$id = isset($_POST['id']) ? $_POST['id'] : '';
$nombre = isset($_POST['nombre']) ? $_POST['nombre'] : '';
$stock = isset($_POST['stock']) ? $_POST['stock'] : '';
$imagen = isset($_POST['imagen']) ? $_POST['imagen'] : '';

if (empty($nombre) || empty($stock) || empty($imagen)) {
    echo "Error: Todos los campos son obligatorios.";
    echo "<br><a href='index.php'>Volver</a>";
    exit;
}

try {
    if (empty($id)) {

        // --- CASO A: AÑADIR NUEVO (INSERT) ---
        $sql = "INSERT INTO vehiculos (nombre, stock, imagen) VALUES (:nombre, :stock, :imagen)";
        $stmt = $db->prepare($sql);
        $stmt->execute([
            'nombre' => $nombre,
            'stock'  => $stock,
            'imagen' => $imagen
        ]);
    } else {
        // --- CASO B: EDITAR EXISTENTE (UPDATE) ---
        $sql = "UPDATE vehiculos SET nombre = :nombre, stock = :stock, imagen = :imagen WHERE id = :id";
        $stmt = $db->prepare($sql);
        $stmt->execute([
            'nombre' => $nombre,
            'stock'  => $stock,
            'imagen' => $imagen,
            'id'     => $id
        ]);
    }

    header("Location: index.php");
    exit;

} catch (PDOException $e) {
    echo "Error al guardar: " . $e->getMessage();
}
?>