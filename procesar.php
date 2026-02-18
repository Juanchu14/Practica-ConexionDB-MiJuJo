<?php
include 'db.php';

// Comprobamos que existe una acción
if (isset($_GET['accion'])) {

    $accion = $_GET['accion'];

    // ELIMINAR VEHÍCULO
    if ($accion == 'eliminar') {

        // Comprobamos que existe el ID
        if (isset($_GET['id']) && !empty($_GET['id'])) {

            $id = $_GET['id'];

            try {

                // Preparamos la consulta
                $stmt = $db->prepare("DELETE FROM vehiculos WHERE id = :id");

                // Ejecutamos
                $stmt->execute(['id' => $id]);

                // Redirigimos al index
                header("Location: index.php");
                exit;

            } catch (PDOException $e) {

                echo "Error al eliminar: " . $e->getMessage();
            }

        } else {

            echo "ID no válido.";
        }

    } else {

        echo "Acción no válida.";
    }

} else {

    echo "No se especificó ninguna acción.";
}
?>
