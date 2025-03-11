const openIcon = document.querySelector('.menu-icon');
const menu = document.querySelector('.menu');

const closeIcon = document.querySelector('.menu-close-icon');


openIcon.addEventListener('click', function () {
    menu.classList.toggle('show'); 
    closeIcon.classList.toggle('show')
});

closeIcon.addEventListener('click', function () {
    menu.classList.toggle('show'); 
    closeIcon.classList.toggle('show')
});

