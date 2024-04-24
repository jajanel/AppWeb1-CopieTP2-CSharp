function afficherFavorisConfirmation(id) {
    document.getElementById("nomConfirmation").innerHTML = "";
    document.getElementById("nomConfirmation").innerHTML = "Confirmer la suppression de ce media ?";
    document.getElementById("confirmationFavorisDelete").style.display = "inline";
    document.getElementById("inputid").setAttribute("value", id);
}

function cacherFavorisConfirmation() {
    document.getElementById("confirmationFavorisDelete").style.display = "none";
}