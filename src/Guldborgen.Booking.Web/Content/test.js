var containers = document.getElementsByClassName("card-container");
var toggles = document.getElementsByClassName("toggle");
var closes = document.getElementsByClassName("close");

function addClass() {
    for (var i = 0; i < containers.length; i++) {
        containers[i].classList.add("active");
    }
}

function removeClass() {
    for (var i = 0; i < containers.length; i++) {
        containers[i].classList.remove("active");
    }
}
