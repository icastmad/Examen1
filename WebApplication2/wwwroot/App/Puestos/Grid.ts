﻿namespace PuestosGrid {

    declare var MensajeApp;

    if (MensajeApp != "") {
        Toast.fire({
            icon: "success", title: MensajeApp
        });
    }

    export function OnClickEliminar(id) {
        ComfirmAlert("Desea eliminar el registro?", "Eliminar", "warning", "#3085d6", "#d33")
            .then(result => {
                if (result.isConfirmed) {
                    window.location.href = "Puestos/Grid?handler=Eliminar&id=" + id;
                }

            });

    }


    $("#GridPuestos").DataTable();
}