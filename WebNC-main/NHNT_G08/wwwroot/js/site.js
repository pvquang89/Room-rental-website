// var deleteBtn = document.getElementById('btn_xoa');
// deleteBtn.addEventListener('click', function () {
//     if (confirm("Bạn có chắc chắn muốn xóa ảnh đại diện?")) {
//         var xhr = new XMLHttpRequest();
//         xhr.open('POST', '/Account/Delete', true);
//         xhr.setRequestHeader('Content-Type', 'application/json');
//         xhr.onload = function () {
//             if (xhr.status === 200) {
//                 // Xử lý thành công
//                 var response = JSON.parse(xhr.responseText);
//                 if (response.success) {
//                     // Xóa ảnh trên giao diện
//                     var avatarImg = document.getElementById('img');
//                     if (avatarImg) {
//                         avatarImg.removeAttribute('src');
//                     }
//                     // Hiển thị thông báo xóa thành công
//                     alert(response.message);
//                 } else {
//                     // Hiển thị thông báo lỗi
//                     alert(response.message);
//                 }
//             } else {
//                 // Xử lý lỗi
//                 console.log("lỗi");
//             }
//         };
//         xhr.send();
//     }
// });


var deleteBtn = document.getElementById('btn_xoa');
deleteBtn.addEventListener('click', function () {
    
    // var avatarImg = document.getElementById('img');
    // if (avatarImg) {
    //     avatarImg.removeAttribute('src');
    // }

    var xhr = new XMLHttpRequest();
    xhr.open('POST', '/Account/Delete', true);
    xhr.onreadystatechange = function () {
        if (xhr.readyState === 4 && xhr.status === 200) {
            var response = JSON.parse(xhr.responseText);
            // Xóa ảnh trên giao diện
            var avatarImg = document.getElementById('img');
            var avatar = document.getElementById('avatar');
            var btnXoa = document.getElementById('btnXoa');
            
            if (avatarImg) {
                
                avatarImg.src = "https://localhost:5001/img/anhdaidien/macdinh.jpg";
                avatar.src = "https://localhost:5001/img/anhdaidien/macdinh.jpg";

            }
            
            btnXoa.style.display = 'none';
            // Hiển thị thông báo xóa thành công
            alert(response.message);
        }
    };
    xhr.send();
});