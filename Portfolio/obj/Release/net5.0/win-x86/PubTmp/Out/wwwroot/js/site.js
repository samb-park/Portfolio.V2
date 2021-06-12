// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



const resumeItem = document.querySelectorAll(".resume_item");

resumeItem.forEach((item) => {
    item.addEventListener("click", (e) => {
        let block = e.target;

        while (block.classList.value != "card-body") {
            block = block.parentNode;
        }

        if (block.childNodes[9].style.display == "none") {
            block.childNodes[9].style.display = "block";
        }
        else {
            block.childNodes[9].style.display = "none";
        }
    })
})
