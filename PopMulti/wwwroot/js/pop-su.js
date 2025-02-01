const popsumulti = document.getElementById('pop-su-multi');
const btn = document.getElementById('btn-pop-su');

const openMouthImg = "/pic/ICT2.png";
const closeMouthImg = "/pic/ICT1.png";
const openMouthSnd = new Audio("/sound/sound-open.mp3");
const closeMouthSnd = new Audio("/sound/sound-close.mp3");

// For Desktop //
btn.addEventListener('mousedown', openMouth);
btn.addEventListener('mouseup', closeMouth);
// For Phone & Tablet devices that has no mouse clicking events //
btn.addEventListener("touchstart", function (e) {
    e.preventDefault();
    openMouth();
})
btn.addEventListener("touchend", function (e) {
    e.preventDefault();
    closeMouth();
})

function openMouth() {
    popsumulti.src = openMouthImg;
    openMouthSnd.play();
}

function closeMouth() {
    popsumulti.src = closeMouthImg;
    closeMouthSnd.play();
}
