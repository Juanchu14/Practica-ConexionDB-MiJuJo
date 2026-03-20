const API_URL = 'http://localhost:5069/api/vehiculos';

document.addEventListener('DOMContentLoaded', () => {
    const urlParams = new URLSearchParams(window.location.search);
    const id = urlParams.get('id');

    const titulo = document.getElementById('titulo-formulario');
    const inputImagen = document.getElementById('imagen');
    const imagenHelp = document.getElementById('imagen-help');

    if (id) {
        titulo.textContent = 'Editar Vehículo';
        inputImagen.required = false; 
        imagenHelp.style.display = 'block';
        cargarDatosVehiculo(id);
    } else {
        titulo.textContent = 'Añadir Vehículo';
        inputImagen.required = true; 
        imagenHelp.style.display = 'none';
    }

    document.getElementById('vehiculo-form').addEventListener('submit', guardarVehiculo);
});

async function cargarDatosVehiculo(id) {
    try {
        const respuesta = await fetch(`${API_URL}/${id}`);
        if (!respuesta.ok) throw new Error("No se pudo cargar el vehículo");
        
        const vehiculo = await respuesta.json();
        
        document.getElementById('vehiculo-id').value = vehiculo.id;
        document.getElementById('nombre').value = vehiculo.nombre;
        document.getElementById('stock').value = vehiculo.stock;
    } catch (error) {
        console.error("Error:", error);
        alert("Error al cargar los datos del vehículo.");
    }
}

async function guardarVehiculo(evento) {
    evento.preventDefault();

    const id = document.getElementById('vehiculo-id').value;
    const nombre = document.getElementById('nombre').value;
    const stock = document.getElementById('stock').value;
    const imagenInput = document.getElementById('imagen');

    const formData = new FormData();
    formData.append('Nombre', nombre);
    formData.append('Stock', stock);
    
    if (imagenInput.files.length > 0) {
        formData.append('Imagen', imagenInput.files[0]);
    }

    try {
        let url = API_URL;
        let method = 'POST';

        if (id) {
            url = `${API_URL}/${id}`;
            method = 'PUT';
        }

        const respuesta = await fetch(url, {
            method: method,
            body: formData
        });

        if (respuesta.ok) {
            window.location.href = 'index.html';
        } else {
            alert("Error al guardar en el servidor.");
        }
    } catch (error) {
        console.error("Error:", error);
        alert("No se pudo conectar con el servidor.");
    }
}