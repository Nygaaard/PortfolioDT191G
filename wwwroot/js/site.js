//Variables
//Hamburger
const openIcon = document.querySelector('.menu-icon');
const menu = document.querySelector('.menu');
const closeIcon = document.querySelector('.menu-close-icon');

//Dark/light mode
const lightModeToggle = document.querySelector('.light-container'); 
const body = document.body; 
const icon = document.querySelector('.dark-light');

//Hamburger toggle
openIcon.addEventListener('click', function () {
    menu.classList.toggle('show'); 
    closeIcon.classList.toggle('show')
});

closeIcon.addEventListener('click', function () {
    menu.classList.toggle('show'); 
    closeIcon.classList.toggle('show')
});

//Dark/light toggle
lightModeToggle.addEventListener('click', function () {
    body.classList.toggle('light-mode');
    
    if (body.classList.contains('light-mode')) {
        icon.classList.remove('fa-circle-half-stroke');
        icon.classList.add('fa-sun');
    } else {
        icon.classList.remove('fa-sun');
        icon.classList.add('fa-circle-half-stroke');
    }
});

//Function to show/hide widget
function toggleTranslateWidget() {
    var translateElement = document.getElementById("google_translate_element");
    if (translateElement.style.display === "none") {
        translateElement.style.display = "block"; //Show widget
    } else {
        translateElement.style.display = "none"; //Hide widget
    }
}

function changeLanguage() {
    var select = document.querySelector(".goog-te-combo");
    var langText = document.getElementById("lang-text");

    if (select) {
        if (select.value === "en") {
            select.value = "sv"; //Switch language to swedish
            langText.innerText = "Språk"; 
        } else {
            select.value = "en"; //Switch to english
            langText.innerText = "Language";
        }
        select.dispatchEvent(new Event("change")); //Activate translation
    }
}

