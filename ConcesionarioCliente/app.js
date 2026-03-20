const API_URL = 'http://localhost:5069/api/vehiculos';
const BASE_SERVER_URL = 'http://localhost:5069'; 

let vehiculosData = [];

document.addEventListener("DOMContentLoaded", cargarVehiculos);

async function cargarVehiculos() {
    try {
        const respuesta = await fetch(API_URL);
        if (!respuesta.ok) throw new Error("Error en la red");
        
        vehiculosData = await respuesta.json();
        renderizarVehiculos();
    } catch (error) {
        console.error("Error al cargar:", error);
        document.getElementById('lista-vehiculos').innerHTML = '<p style="text-align:center; grid-column: 1/-1; color: #D40000;">Error al conectar con el servidor.</p>';
    }
}

function renderizarVehiculos() {
    const contenedor = document.getElementById('lista-vehiculos');
    const textoBusqueda = document.getElementById('buscador').value;
    const tipoOrden = document.getElementById('orden').value;

    let vehiculosFiltrados = vehiculosData.filter(v => {
        const nombreNormalizado = v.nombre.normalize("NFD").replace(/[\u0300-\u036f]/g, "").toLowerCase();
        const busquedaNormalizada = textoBusqueda.normalize("NFD").replace(/[\u0300-\u036f]/g, "").toLowerCase();
        return nombreNormalizado.includes(busquedaNormalizada);
    });

    vehiculosFiltrados.sort((a, b) => {
        const nombreA = a.nombre.toLowerCase();
        const nombreB = b.nombre.toLowerCase();
        if (tipoOrden === 'asc') {
            return nombreA < nombreB ? -1 : (nombreA > nombreB ? 1 : 0);
        } else {
            return nombreA > nombreB ? -1 : (nombreA < nombreB ? 1 : 0);
        }
    });

    contenedor.innerHTML = '';
    
    if (vehiculosFiltrados.length === 0) {
        contenedor.innerHTML = '<p style="text-align:center; grid-column: 1/-1;">No se encontraron vehículos.</p>';
        return;
    }

    vehiculosFiltrados.forEach(v => {
        const rutaImagen = v.imagenUrl ? `${BASE_SERVER_URL}${v.imagenUrl}` : 'https://via.placeholder.com/300x200?text=AMG';

        contenedor.innerHTML += `
            <div class="vehiculo-card">
                <div class="card-image-container">
                    <img src="${rutaImagen}" alt="${v.nombre}">
                </div>
                <div class="card-content">
                    <h3>${v.nombre}</h3>
                    <p>Stock disponible: <strong>${v.stock} unidades</strong></p>
                    <div class="card-actions">
                        <a href="formulario.html?id=${v.id}" class="btn">Editar</a>
                        <button onclick="borrarVehiculo(${v.id})" class="btn-delete">Eliminar</button>
                    </div>
                </div>
            </div>
        `;
    });
}

async function borrarVehiculo(id) {
    const confirmacion = confirm("WARNING!!!.ESTAS A PUNTO DE BORRAR UN VEHICULO");
    if (!confirmacion) return;

    try {
        const respuesta = await fetch(`${API_URL}/${id}`, {
            method: 'DELETE'
        });

        if (respuesta.ok) {
            cargarVehiculos();
        } else {
            alert("Error al eliminar el vehículo.");
        }
    } catch (error) {
        console.error("Error:", error);
    }
}