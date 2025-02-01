// Source button, img and sound //
const popkmuttmulti = document.getElementById('pop-kmutt-multi');
const btn = document.getElementById('btn-pop-kmutt');
const openMouthImg = "/pic/Cmm2.png";
const closeMouthImg = "/pic/Cmm1.png";
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

// Click to change the img between close & open mouth //
function openMouth() { 
    popkmuttmulti.src = openMouthImg;
    openMouthSnd.play();
}
function closeMouth() {
    popkmuttmulti.src = closeMouthImg;
    closeMouthSnd.play();
}
