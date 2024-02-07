var modalImg = $('#img01');
var captionText = $('#caption');

$(document).on("click", ".image", function () {
      //alert('')
    $('#myModal').css('display', 'block');
    $('#img01').attr('src', this.src);
    //$('#caption').html('src', this.alt);
});

// Get the <span> element that closes the modal
var span = document.getElementsByClassName("close")[0];
span.onclick = function () {
    //alert('1')
    $('#myModal').css('display', 'none');
}
$(document).on("click", ".close", function () {
    //alert('2')
  $('#myModal').css('display', 'none');
});
//$(document).on("click", "body:not(#myModal)", function () {
//    alert('')
//    $('#myModal').css('display', 'none');
//});