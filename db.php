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
            ["nombre" => "Mercedes Benz a45", "imagen" => "a45.png"],
            ["nombre" => "Mercedes Benz cla45", "imagen" => "cla45.png"],
            ["nombre" => "Mercedes Benz c63", "imagen" => "c63.png"],
            ["nombre" => "Mercedes Benz cls63", "imagen" => "cls63.png"],
            ["nombre" => "Mercedes Benz g63", "imagen" => "g63.png"],
            ["nombre" => "Mercedes Benz gle63", "imagen" => "gle63.png"],
            ["nombre" => "Mercedes Benz GLS", "imagen" => "gls.png"],
            ["nombre" => "Mercedes Benz gt63", "imagen" => "gt63.png"],
            ["nombre" => "Mercedes Benz maybach", "imagen" => "maybach.png"],
            ["nombre" => "Mercedes Benz sls", "imagen" => "sls.png"],
            ["nombre" => "BMW alpinab7", "imagen" => "alpinab7.png"],
            ["nombre" => "BMW i8", "imagen" => "i8.png"],
            ["nombre" => "BMW m2", "imagen" => "m2.png"],
            ["nombre" => "BMW m3 competition touring", "imagen" => "m3competitiontouring.png"],
            ["nombre" => "BMW m4 competition", "imagen" => "m4competition.png"],
            ["nombre" => "BMW m5 cs", "imagen" => "m5cs.png"],
            ["nombre" => "BMW m8 competition", "imagen" => "m8competition.png"],
            ["nombre" => "BMW serie 8 convertible", "imagen" => "serie8convertible.png"],
            ["nombre" => "BMW xm ", "imagen"=>"xm.png"], 
            ["nombre"=> "BMW z4m 40i","imagen"=>"z4m40i.png"], 
            ["nombre"=>"Audi q8 e-tron","imagen"=>"q8e-tron.png"], 
            ["nombre"=>"Audi r8","imagen"=>"r8.png"], 
            ["nombre"=>"Audi rs3","imagen"=>"rs3.png"], 
            ["nombre"=>"Audi rs5 coupe","imagen"=>"rs5coupe.png"], 
            ["nombre"=>"Audi rs6","imagen"=>"rs6.png"], 
            ["nombre"=>"Audi rs7","imagen"=>"rs7.png"], 
            ["nombre"=>"Audi rs e-tron gt","imagen"=>"rse-trongt.png"], 
            ["nombre"=>"Audi rsq8","imagen"=>"rsq8.png"], 
            ["nombre"=>"Audi ttrs","imagen"=>"ttrs.png"], 
            ["nombre"=>"Audi s8","imagen"=>"s8.png"]
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