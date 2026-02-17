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

    $check = $db->query("SELECT COUNT(*) FROM vehiculos")->fetchColumn();

    if ($check == 0) {
        $inventario = [
            ["nombre" => "Toyota Corolla", "imagen" => "corolla.jpg"],
            ["nombre" => "Seat Ibiza", "imagen" => "ibiza.jpg"],
            ["nombre" => "Renault Clio", "imagen" => "clio.jpg"],
            ["nombre" => "Volkswagen Golf", "imagen" => "golf.jpg"],
            ["nombre" => "Ford Focus", "imagen" => "focus.jpg"],
            ["nombre" => "Peugeot 208", "imagen" => "208.jpg"],
            ["nombre" => "Hyundai i30", "imagen" => "i30.jpg"],
            ["nombre" => "Kia Ceed", "imagen" => "ceed.jpg"],
            ["nombre" => "Opel Corsa", "imagen" => "corsa.jpg"],
            ["nombre" => "Citroën C3", "imagen" => "c3.jpg"],
            ["nombre" => "BMW Serie 1", "imagen" => "serie1.jpg"],
            ["nombre" => "Audi A3", "imagen" => "a3.jpg"],
            ["nombre" => "Mercedes Clase A", "imagen" => "clasea.jpg"],
            ["nombre" => "Fiat 500", "imagen" => "500.jpg"],
            ["nombre" => "Dacia Sandero", "imagen" => "sandero.jpg"],
            ["nombre" => "Nissan Qashqai", "imagen" => "qashqai.jpg"],
            ["nombre" => "Mazda 3", "imagen" => "mazda3.jpg"],
            ["nombre" => "Skoda Fabia", "imagen" => "fabia.jpg"],
            ["nombre" => "Volvo V40", 	"imagen"=>"v40.jpg"], 
            ["nombre"=>"Honda Civic","imagen"=>"civic.jpg"], 
            ["nombre"=>"Alfa Romeo Giulietta","imagen"=>"giulietta.jpg"], 
            ["nombre"=>"Mini Cooper","imagen"=>"cooper.jpg"], 
            ["nombre"=>"Lexus CT","imagen"=>"ct.jpg"], 
            ["nombre"=>"Tesla Model 3","imagen"=>"model3.jpg"], 
            ["nombre"=>"Jeep Renegade","imagen"=>"renegade.jpg"], 
            ["nombre"=>"Suzuki Swift","imagen"=>"swift.jpg"], 
            ["nombre"=>"Mitsubishi Space Star","imagen"=>"spacestar.jpg"], 
            ["nombre"=>"Subaru Impreza","imagen"=>"impreza.jpg"], 
            ["nombre"=>"Jaguar XE","imagen"=>"xe.jpg"], 
            ["nombre"=>"Porsche Taycan","imagen"=>"taycan.jpg"]
        ];

        $stmt = $db->prepare("INSERT INTO vehiculos (nombre, stock, imagen) VALUES (:nombre, :stock, :imagen)");

        foreach ($inventario as $coche) {
            $stmt->execute([
                'nombre' => $coche['nombre'],
                'stock'  => rand(1, 15),
                'imagen' => $coche['imagen'] 
            ]);
        }
    }
} catch (PDOException $e) {
    echo "Error: " . $e->getMessage();
    exit;
}
?>