function mudarImagem1() {
    document.getElementById("produtinho_selecionado").src = document.getElementById("produto_1").src;
}
function mudarImagem2() {
    document.getElementById("produtinho_selecionado").src = document.getElementById("produto_2").src;
}
function mudarImagem3() {
    document.getElementById("produtinho_selecionado").src = document.getElementById("produto_3").src;
}
function mudarImagem4() {
    document.getElementById("produtinho_selecionado").src = document.getElementById("produto_4").src;
}
// Get the modal
var modal = document.getElementById('id01');

// When the user clicks anywhere outside of the modal, close it
window.onclick = function(event) {
  if (event.target == modal) {
    modal.style.display = "none";
  }
}