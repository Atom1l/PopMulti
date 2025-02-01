const popkmuttmulti = document.getElementById('pop-swu-multi');
const btn = document.getElementById('btn-pop-swu');

const openMouthImg = "/pic/Swu2.png";
const closeMouthImg = "/pic/Swu1.png";
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
    popkmuttmulti.src = openMouthImg;
    openMouthSnd.play();
}

function closeMouth() {
    popkmuttmulti.src = closeMouthImg;
    closeMouthSnd.play();
}
