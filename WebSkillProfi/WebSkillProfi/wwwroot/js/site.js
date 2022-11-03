document.addEventListener('DOMContentLoaded', function () {
    var btn = document.getElementById('btn__request');
    var pizza = document.getElementsByClassName("section__request-form")[0];
    console.log(pizza.className);

    btn.addEventListener('click', function (e) {
        pizza.classList.remove('section__request-form');
    });


});