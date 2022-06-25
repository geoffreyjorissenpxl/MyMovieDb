// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


let mediaContainers = [...document.querySelectorAll('.card-container')];
let nextButton = [...document.querySelectorAll('.next-btn')];
let previousButton = [...document.querySelectorAll('.previous-btn')];

mediaContainers.forEach((item, i) => {
    let containerDimensions = item.getBoundingClientRect();
    let containerWidth = containerDimensions.width;

    nextButton[i].addEventListener('click', () => {
        item.scrollLeft += containerWidth;
    })

    previousButton[i].addEventListener('click', () => {
        item.scrollLeft -= containerWidth;
    })
})