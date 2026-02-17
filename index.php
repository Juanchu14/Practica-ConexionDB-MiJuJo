<?php
    include 'db.php';

    $vehiculos = []; // inicamos la variable con un array vacio
     
    $busqueda = isset($_GET['buscar']) ? $_GET['buscar'] : ''; 
    $orden = (isset($_GET['orden']) && $_GET['orden'] == 'DESC') ? 'DESC' : 'ASC'; 

    try {
        
        $sql = "SELECT * FROM vehiculos WHERE nombre LIKE :busqueda ORDER BY nombre $orden"; 
        
        $stmt = $db->prepare($sql); // Preparamos para evitar Inyección SQL
        $stmt->execute(['busqueda' => "%$busqueda%"]);
        
        $vehiculos = $stmt->fetchAll(PDO::FETCH_ASSOC); 
        
    } catch (PDOException $e) {
        echo "<p style='color:red;'>Error en la base de datos: " . $e->getMessage() . "</p>";
    }
?>

<!DOCTYPE html>
<html lang="es">
    <head>
        <meta charset="UTF-8">
        <title>Concesionario - Inventario</title>
        <link rel="stylesheet" href="style.css">
    </head>
    <body>
        <h1>Gestión de Inventario</h1>

        <input type="button" value="Añadir Vehículo" onclick="window.location.href='formulario.php'">

        <form method="GET" action="index.php">
            <input type="text" name="buscar" placeholder="Buscar por nombre..." value="<?php echo htmlspecialchars($busqueda); ?>">
            <select name="orden">
                <option value="ASC" <?php if ($orden == 'ASC') echo 'selected'; ?>>Alfabético (A-Z)</option>
                <option value="DESC" <?php if ($orden == 'DESC') echo 'selected'; ?>>Alfabético (Z-A)</option>
            </select>
            <button type="submit">Buscar</button>
        </form>

        <br>

        <table border="1" style="width:100%; text-align:left; border-collapse: collapse;">
            <thead>
                <tr style="background-color: #f2f2f2;">
                    <th>Imagen</th> 
                    <th>Nombre</th> 
                    <th>Stock</th>  
                    <th>Acciones</th> 
                </tr>
            </thead>
            <tbody>
                <?php if (count($vehiculos) > 0): ?>
                    <?php foreach ($vehiculos as $item): ?>
                    <tr>
                        <td><img src="imagenes/<?php echo $item['imagen']; ?>" width="80" alt="Coche"></td>
                        <td><?php echo htmlspecialchars($item['nombre']); ?></td>
                        <td><?php echo $item['stock']; ?> unidades</td>
                        <td>
                            <a href="formulario.php?id=<?php echo $item['id']; ?>">Editar</a>
                            <button onclick="confirmarBorrado(<?php echo $item['id']; ?>, '<?php echo $item['nombre']; ?>')">Eliminar</button>
                        </td>
                    </tr>
                    <?php endforeach; ?>
                <?php else: ?>
                    <tr><td colspan="4">No se han encontrado vehículos.</td></tr>
                <?php endif; ?>
            </tbody>
        </table>

        <script>
        
        function confirmarBorrado(id, nombre) {
            if (confirm("¿Estás seguro de que deseas eliminar el vehículo: " + nombre + "?")) {
                
                window.location.href = "procesar.php?accion=eliminar&id=" + id;
            }
        }
        </script>
    </body>
</html>