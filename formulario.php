<?php
include 'db.php'; 

// Comprobamos si recibimos un ID para saber si editamos o añadimos
$id = isset($_GET['id']) ? $_GET['id'] : '';
$vehiculo = null;

if (!empty($id)) {
    // Si hay ID, buscamos los datos actuales para autorrellenar
    $stmt = $db->prepare("SELECT * FROM vehiculos WHERE id = :id");
    $stmt->execute(['id' => $id]);
    $vehiculo = $stmt->fetch(PDO::FETCH_ASSOC);
}
?>

<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <title><?php echo $vehiculo ? 'Editar Vehículo' : 'Añadir Vehículo'; ?></title>
    <link rel="stylesheet" href="style.css"> </head>
<body>
    <h1><?php echo $vehiculo ? 'Modificar Vehículo' : 'Nuevo Vehículo'; ?></h1>

    <form action="guardar.php" method="POST">
        <input type="hidden" name="id" value="<?php echo $id; ?>">

        <label>Nombre del Modelo:</label><br>
        <input type="text" name="nombre" 
               value="<?php echo $vehiculo ? htmlspecialchars($vehiculo['nombre']) : ''; ?>" 
               required placeholder="Ej: Toyota Corolla"><br><br>

        <label>Unidades en Stock:</label><br>
        <input type="number" name="stock" 
               value="<?php echo $vehiculo ? $vehiculo['stock'] : ''; ?>" 
               required min="0"><br><br>

        <label>Nombre de la imagen:</label><br>
        <input type="text" name="imagen" 
               value="<?php echo $vehiculo ? htmlspecialchars($vehiculo['imagen']) : ''; ?>" 
               required placeholder="Ej: corolla.jpg"><br>
        <small>Las fotos deben estar en la carpeta <strong>/imagenes</strong></small><br><br>

        <button type="submit"><?php echo $vehiculo ? 'Actualizar Vehículo' : 'Guardar Nuevo'; ?></button>
        <br><br>
        <a href="index.php">Cancelar y Volver al Inventario</a> </form>

</body>
</html>