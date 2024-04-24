function afficherConfirmation(prenom, nom, courriel) {
    document.getElementById("nomConfirmation").innerHTML = "";
    document.getElementById("nomConfirmation").innerHTML= "Confirmer la suppresion de " + prenom + " " + nom + "?";
    document.getElementById("confirmationDelete").style.display = "inline";
    document.getElementById("inputCourriel").setAttribute("value", courriel);
}


function cacherConfirmation() {
    document.getElementById("confirmationDelete").style.display = "none";
}