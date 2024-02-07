//const { file } = require("grunt");
//const File = require("vinyl");
//const { FormData } = require("../../bower_components/inputmask/dist/inputmask/global/window");

$(document).ready(function () {
    /* change parent color when input checked */
    $(".radio-wrapper .radioDiv input[type=radio]").change(function () {
        if (this.checked) {
            //Do stuff
            //alert($(this).attr("id"));
            $(".radio-wrapper input[type=radio]").parent().removeClass("active");
            $(this).parent().addClass("active");
        }
    });

    /* change parent color when input checked */
    $(".radio-wrapper .groupRadio input[type=radio]").change(function () {
        if (this.checked) {
            //Do stuff
            //alert($(this).attr("id"));
            if ($(this).attr("id") == "public") {
                $('#private').prop('checked', false);
            } else {
                $('#public').prop('checked', false);
            }

            $(".radio-wrapper input[type=radio]").parent().parent().removeClass("active");
            $(this).parent().parent().addClass("active");

        }
    });

    $(".groupOptions").click(function (e) {
        e.preventDefault();
        e.stopPropagation();
        $(this).parent().find(".optionPopup").toggle('show');
    })
    $(".groupOptions-wrapper .optionPopup a").click(function (e) {
        e.preventDefault();
        e.stopPropagation();
    })
    $(".deleteGroup").click(function (e) {
        var id = $(this).attr("id");
        $('#GroupIdDelete').val(id);
        $("#deleteGroupModal").modal("show");
        $('.optionPopup').css('display', 'none');
    })

    //function FilterGroups(filter, item) {
    //    $('#groupsGrid').html('');
    //  LoadSkeleton();
    //    $(item).addClass('active');
    //    $.get("/home/FilteredGroups?filter=" + filter, function (data) {
    //        $('#groupsGrid').html(data);
    //    });
    //}
    $(document).on("click", "#acceptDeleteGroup", function () {
        debugger
        var id = $('#GroupIdDelete').val();
        $.post("/Groups/delete/" + id, function (res) {
            if (res == true) {
                $('#GroupIdDelete').val('');
                alert('تم الحذف بنجاح')
                window.location.reload();
            } else {
                alert('حدث خطا حاول مرة اخرى')
            }
        });
    });
    //click the filter in Home page
    const grid = document.querySelector('#groupsGrid')
    const cardTemplate = document.getElementById('card-template')
    $('.groupFilterItem').click(function () {
        $('#groupsGrid').html('');
        LoadGroupsSkeleton();
        $(this).addClass('active');
        var filter = $(this).attr('id');
        $.get("/home/FilteredGroups?filter=" + filter, function (data) {
            $('#groupsGrid').html(data);
        });
    });
    function LoadGroupsSkeleton() {
        for (let i = 0; i < 6; i++) {
            grid.prepend(cardTemplate.content.cloneNode(true));
        }
    }

    $(document).on("click", ".declineDelete", function () {
        $("#deleteGroupModal").modal("hide");
        $("#deletePostModal").modal("hide");
        $('#GroupIdDelete').val('');
        $('#PostIdDelete').val('');
    });






    $(".notificationBell").click(function (e) {
        /*e.stopPropagation();*/
        $(".notificationsMenu").toggle();
    })

    $(".orderDropdown input[type='radio']").change(function () {
        var checkedText = $(this).parent().find("a").html();
        var buttonOrder = $(this).parent().parent().parent().find(".orderButton");
        $(buttonOrder).html(checkedText);
    });
    $(".orderDropdown .dropdown-item").click(function () {
        var checkedText = $(this).find("a").html();
        var buttonOrder = $(this).parent().parent().find(".orderButton");
        //$(this).find(".checkmark").css("border", "solid 5px #00adbe");
        //$(this).find(".checkmark").css("background-color", "#00adbe");
        $(buttonOrder).html(checkedText);
    });
    /* append new comment and reply input field */
    //$(".addComment").click(function () {
    //    var comment = $(this).parent().find(".commentText").val();

    //    if (comment !== "") {
    //        var postId = $(this).parent().find(".postId").val();
    //        var postGuid = $(this).parent().find(".postGuid").val();
    //        var added = AddPostComment(comment, postId, accountGuid);
    //        //alert(added)
    //        if (added == true) {

    //            var div = " <div class=\"col-12 postComment\">" + " <div class=\"row justify-content-end\">" + "<div class=\"col-12 col-md-12 col-lg-12 comment\">" + "<div class=\"row\">" + "<div class=\"col-auto userDp\">" + "<img src=\"imgs/group.jpg\">" +
    //                " </div>" + "<div class=\"col userInfo\">" + "<div class=\"d-flex align-items-center\">" + "<p class=\"userPosted\">محمد حسن احمد</p>" +
    //                " </div>" + "<p class=\"postDate\"><i></i>  <span>تاريخ النشر</span> 20/5/2022</p>" + " <p>" + comment + "</p>" +
    //                "<div class=\"socialInfo\">" + "  <p> 0 <i class=\"comments\"></i></p>" + "<p> 0 <i class=\"likes\"></i></p>" +
    //                " <p> 0 <i class=\"share\"></i></p>" + "</div>" + " </div>" + "</div>" + "</div>" + "<div class=\"col-11 replies pr-0\">" +
    //                "<div class=\"row\">" + " <div class=\"repliesWrapper\"> </div>" + " <div class=\"input-wrapper replyInput\">" +
    //                "<input type=\"text\" class=\"form-control\" placeholder=\"اضف الرد هنا\">" + "<img src=\"imgs/userDefault.png\" class=\"addCommentDp\">" +
    //                "<a href=\"javascript:void(0)\" class=\"addReply\"></a>" + "</div>" + "</div>" + "</div>" + "</div>" + "</div>";
    //            $(this).parent().parent().find(".commentsWrapper").prepend(div);
    //            $(this).parent().find(".commentText").val('')
    //        }
    //        else {

    //        }
    //    }
    //});

    //function AddPostComment(comment, postId, accountGuid) {
    //    for (let i = 0; i < 1; i++) {
    //        grid.prepend(cardTemplate.content.cloneNode(true))
    //    }

    //    $.ajax({
    //        type: "POST",
    //        url: '@Url.Action("AddPostComment", "posts")',
    //        data: {
    //            accountGUID: accountGuid,
    //            postId: postId,
    //            text: comment
    //        },
    //        success: function (result) {
    //            return result;
    //            /* if (result == true) {

    //                 $(".commentText").val('');
    //                 commentsCount += 1;
    //                 $("#lastdate").val('');
    //                 GetPostComments();
    //             } else {
    //                 alert("حدث خطأ حاول مرة اخرى");
    //             }*/
    //        }
    //    });
    //}



    /* append new reply **/


    $('#postImg,#postImg2,#postImg3, #postImgService').on('change', function () {
        debugger
        myfile = $(this).val();
        var ext = myfile.toLowerCase().split('.').pop();
        if (ext == "png" || ext == "gif" || ext == "jpg" || ext == "jpeg") {
            loadFile(this, '');
        } else {
            $(this).val('');
            alert("من فضلك أختر صورة بشكل صحيح");
        }
    });
    $('#coverImg').on('change', function () {
        debugger
        var myfile = $(this);
        var ext = myfile.val().toLowerCase().split('.').pop();
        if (ext == "png" || ext == "jpg" || ext == "jpeg") {
            changeImg(this, 'imgCoverSourceImage');
        } else {
            $(this).val('');
            alert("من فضلك أختر صورة بشكل صحيح");
        }
    });
    $('#dpImg').on('change', function () {
        myfile = $(this).val().toLowerCase();
        var ext = myfile.split('.').pop();
        if (ext == "png" || ext == "jpg" || ext == "jpeg") {
            changeImg(this, 'imgProfileSourceImage');
        } else {
            $(this).val('');
            alert("من فضلك أختر صورة بشكل صحيح");
        }
    });
    $('#userImg').on('change', function () {
        myfile = $(this).val().toLowerCase();
        var ext = myfile.split('.').pop();
        if (ext == "png" || ext == "jpg" || ext == "jpeg") {
            changeImg(this);
        } else {
            $(this).val('');
            alert("من فضلك أختر صورة بشكل صحيح");
        }
    });
    $('#profileImage').on('change', function () {
        var myfile = $(this);
        var ext = myfile.val().toLowerCase().split('.').pop();
        if (ext == "png" || ext == "jpg" || ext == "jpeg") {
            changeImg(this, 'imgProfileSourceImage');
        } else {
            $(this).val('');
            alert("من فضلك أختر صورة بشكل صحيح");
        }
    });

    $(".postImgs").on("click", ".clearImg", function () {
        $(this).parent().remove();
        if (image1Added == true) {
            image1Added = false;
        }
        else if (image2Added == true) {
            image2Added = false;
        }
        else if (image2Added == true) {
            image1Added = false;
        }
    });

    /* display inner menu for active group */
    var activeGroup = $(".sideList .dropdown-item.active");
    $(activeGroup).parent().find(".activeGroup").show();

    /* get selected admins and append them to div */


    $(".textarea-wrapper textarea").keyup(function () {
        let value = $(this).val();
        if (value.trim() !== "") {

            $(document).find(".addSharePost").addClass("addActive");
        }
        else {
            $(document).find(".addSharePost").removeClass("addActive");
        }
    })

})
function ValidatePost() {
    debugger
    var image_1 = document.getElementById("postImg").files[0];
    var image_2 = document.getElementById("postImg2").files[1];
    var image_3 = document.getElementById("postImg3").files[2];
    var description = $('#description').val().trim();
    if (image_1 != null || image_2 != null || image_3 != null || description != "") {
        return true;
    }
    return false;
}

$(".addSharePost22").click(function () {
    var formData = new FormData();
    var images = $('.attachedImg').find('img').attr('src');
    //alert(images)
    var image_1 = document.getElementById("attachedImgs").files[0];
    var image_2 = document.getElementById("attachedImgs").files[1];
    var image_3 = document.getElementById("attachedImgs").files[2];
    // alert(images)
    /*  alert($('#attachedImgs').files[0]);*/
    //  formData.append("image", images);
    //var superBuffer = new Blob(image_1, { type: 'image/png' });
    formData.append("description", $('#description').val());
    formData.append("image", new Blob(image_1, { type: 'image/png' }));
    formData.append('image2', new Blob(image_2, { type: 'image/png' }));
    formData.append('image3', new Blob(image_3, { type: 'image/png' }));
    $.ajax({
        url: "/posts/addpost",
        data: formData,
        type: "Post",
        contentType: false,
        processData: false,
        cache: false,
        success: function (result) {
            //alert(result)
            if (result == true) {

            } else if (result == 'fillItems') {
                alert('من فضلك أدخل البيانات المطلوبة')
            }
            else {
                alert('حدث خط');
            }
        },
        error: function (e) {
            if (e.status == "401") {
            } else {
                //errorfound();
            }
        }
    });
});



function openNav() {
    //debugger
    /* open navbar in mobile */
    $("#overlayBg").fadeIn();
    document.getElementById("myNav").style.width = "80%";
}
//function removeAdmin(item) {
//    var id = $(item).attr("id");
//    $(item).parent().remove();
//}
function removeAdmin(item) {
    debugger
    if (confirm("هل تريد الغاء هذا العضو كمسؤل فى المجموعة؟")) {
        var user = {
            groupId: $(item).parent().parent().find('#groupId').val(),
            accountId: $(item).attr('id'),
            isAdmin: false
        }
        $.post("/GroupUsers/AssignOrDeleteAdmin", { user: user }, function (result) {
            if (result == true) {
                $(item).parent().remove();
                alert('تم الغاء الادمن...')
            } else {
                alert('حدث خطأ حاول مره اخرى')
            }
        });
    }
}
function SerachMemebers(item) {
    var inputField = $(item).val();
    /* if (inputField != null && inputField !== "") {*/
    var groupId = $(item).parent().find('#adminGroupId').val();

    $(".searchIcon").show();
    $('.membersAdmin-wrapper').html('');
    $.get('/GroupUsers/MembersJson?key=' + inputField + '&groupId=' + groupId, function (res) {
        var rows = '';
        $.each(res, function (i, item) {
            var html = '<div class="groupRadio">' +
                '<label for= "' + item.id + '">' +
                '<input type="checkbox" name="adminMember" value="' + item.name + '" id="' + item.id + '">' +
                '<span class="checkmark" ></span >' + item.name +
                '</label>' +
                '</div>';
            rows += html;
        });
        $('.membersAdmin-wrapper').prepend(rows);
    });
    //}
    //else {

    //}




}


var firstItems = [];
//to fill popup modal with users
$('.addAdmin,.addAdminGroup').click(function () {
    $('.membersAdmin-wrapper').html('');
    var id = $(this).attr('id');
    //Set GroupId
    $('#adminGroupId').val(id);
    $.get('/GroupUsers/MembersJson?groupId=' + id, function (res) {
        firstItems = res;
        var rows = '';
        $.each(res, function (i, item) {
            var html = '<div class="groupRadio">' +
                '<label for= "' + item.id + '">' +
                '<input type="checkbox" name="adminMember" value="' + item.name + '" id="' + item.id + '">' +
                '<span class="checkmark" ></span >' + item.name +
                '</label>' +
                '</div>';
            rows += html;
        });
        $('.membersAdmin-wrapper').append(rows);
    });
});
var image1Added = false;
var image2Added = false;
var image3Added = false;
function openFileUpload(item, e) {
    debugger
    e.preventDefault();
    if (image1Added == false /*&& image2Added == false && image3Added == false*/) {
        $(item).parent().find("#postImg").click();
        image1Added = true;
    } else if (image2Added == false /*&& image2Added == false && image3Added == false*/) {
        $(item).parent().find("#postImg2").click();
        image2Added = true;
    } else if (image3Added == false /*&& image2Added == true && image3Added == false*/) {
        $(item).parent().find("#postImg3").click();
        image3Added = true;
    }
}
$('.editProfileImage').click(function () {
    
    if (confirm("هل تريد تغيير الصورة الشخصيه")) {
         $(this).parent().find("#userProfileImgBrowser").click();
    }
})
$('#userProfileImgBrowser').on('change', function () {
    debugger
    var formData = new FormData();
    var image = document.getElementById("userProfileImgBrowser").files[0];
    formData.append('image', image);
    var accountId = $('#userAccountId').val();
        formData.append('accountId', accountId);
    $.ajax({
        url: "https://api.rashaqa.net/api/users/UpdateProfileImage?accountId=" + accountId,
        data: formData ,
        type: "Post",
        contentType: false,
        processData: false,
        cache: false,
        success: function (result) {
            //alert(result["imageURL"])
            var image = result["imageURL"];
            localStorage.setItem("profileImage", image);
            $('#userProfileImage').attr('src', image);
            window.location.reload();
        },
        error: function (e) {
            alert( e.responseText)
            if (e.status == "401") {
            } else {
                //errorfound();
            }
        }
    });
   // debugger
   //var myfile = $(this).val();
   // var ext = myfile.toLowerCase().split('.').pop();
   // if (ext == "png" || ext == "gif" || ext == "jpg" || ext == "jpeg") {
   //     if (myfile.files && myfile.files[0]) {
   //         var src = window.URL.createObjectURL(myfile.files[0]);
   //         $(this).parent().parent().find("#userProfileImage").attr('src', src);
   //     }
   // }
   // else {
   //     myfile.val('');
   //     alert("file is not image");
   // }
});

function loadFile(uploader) {
    debugger
    //alert(uploader.files[0])
    if (uploader.files && uploader.files[0]) {
        var src = window.URL.createObjectURL(uploader.files[0]);
        var div = "<div class=\"attachedImg\">" + "<img name='myImages' src= " + src + ">" + " <div class=\"imgOverlay clearImg\">" + "</div>" + "<input  value=" + src + " id='attachedImgs' type='file'/> </div>";
        $(".postImgs").append(div);
    }
}
function closeNav() {
    $("#overlayBg").fadeOut();
    document.getElementById("myNav").style.width = "0%";
}
function changeImg(uploader, imgCoverSourceImageId) {
    if (uploader.files && uploader.files[0]) {
        let src = window.URL.createObjectURL(uploader.files[0]);
        if (imgCoverSourceImage != '') {
            $("#" + imgCoverSourceImageId).attr("src", src);
        } else {
            $(uploader).parent().parent().find("img").attr("src", src);
        }
    }
}

var groupId = localStorage.getItem("currentGroupId");


var inputWidth = $("#searchAuto").outerWidth();
//alert(inputWidth);

$(function () {
    var $elem = $("#searchAuto").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "/posts/Search",
                data: { groupId: groupId, key: $("#searchAuto").val() },
                dataType: "json",
                type: "get",
                contentType: "application/json; charset=utf-8",
                // dataFilter: function (data) { alert("erro " + data); return data; },
                success: function (data) {

                    response($.map(data, function (item) {
                        //alert(item)
                        return item;
                    }));
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    var err = eval("(" + XMLHttpRequest.responseText + ")");
                    alert(err)
                }
            });
        },
        open: function () { $(".ui-autocomplete").outerWidth(inputWidth) },
        position: { my: "left top-15", at: "left bottom" },
        select: function (e, i,) {
            window.location.href = "/posts/details/" + i.item.id
        }
    }),
        elemAutocomplete = $elem.data("ui-autocomplete") || $elem.data("autocomplete");
    if (elemAutocomplete) {
        elemAutocomplete._renderItem = function (ul, item) {
            var newText = String(item.description).replace(
                new RegExp(this.term, "gi"),
                "<span class='ui-state-highlight'>$&</span>");

            return $("<li></li>")
                .data("ui-item.autocomplete", item)
                .append("<div>" + newText + "</div>")
                .appendTo(ul);
        };
    }

});


function checkInput() {
    var inputField = $("#searchAuto").val();
    if (inputField != null && inputField !== "") {
        $("#clear").show();
        $(".searchIcon").show()
    }
    else {
        $("#clear").hide();
    }
}
function searchForPosts(key) {
    var groupId = localStorage.getItem("currentGroupId");
    $.get("/posts/Search?groupId=" + groupId + "&key=" + key, function (res) {
        var rows = '';
        $.each(res, function (i, item) {
            //alert(item.description)
            availableTags.push(item.description);
        });
    });
}


function clearText() {
    $("#searchAuto").val("");
    $("#clear").hide();
}
$(document).mouseup(function (e) {
    var container = $(".postOptions-wrapper, .notification-wrapper");

    // if the target of the click isn't the container nor a descendant of the container
    if (!container.is(e.target) && container.has(e.target).length === 0) {

        container.find(".notificationsMenu, .optionPopup").hide();
    }
});
