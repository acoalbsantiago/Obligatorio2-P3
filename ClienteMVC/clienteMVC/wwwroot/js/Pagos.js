document.addEventListener("DOMContentLoaded", function () {
    // Tomamos el select y los divs
    const tipoPagoSelect = document.getElementById("TipoDePago");
    const camposUnico = document.getElementById("campos-unico");
    const camposRecurrente = document.getElementById("campos-recurrente");

    if (!tipoPagoSelect) return; // previene errores si no existe el select

    function toggleCampos() {
        const valor = tipoPagoSelect.value;

        if (valor === "1") { // Unico
            camposUnico.style.display = "block";
            camposRecurrente.style.display = "none";
        } else if (valor === "2") { // Recurrente
            camposUnico.style.display = "none";
            camposRecurrente.style.display = "block";
        } else {
            camposUnico.style.display = "none";
            camposRecurrente.style.display = "none";
        }
    }

    // Detectamos cambios en el select
    tipoPagoSelect.addEventListener("change", toggleCampos);

    // Inicializamos la vista según el valor actual
    toggleCampos();
});
