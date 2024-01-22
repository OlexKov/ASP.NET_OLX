let imageUrls = [];
$errorText = $('#imagesError');
$images = $('#imageContainer > div');
$imageFiles = $('#imageFiles')[0];
imageExist();
const newArray = new DataTransfer();
function displayNames(event) {
    $errorText.text("");
    $files = event.files;
    for (let i = 0; i < $files.length; i++) {
        newArray.items.add($files[i]);
        let url = URL.createObjectURL($files[i]);
        $images.append(`
            <div class="my-2"style="height:140px;width:200px;">
                <img style="object-fit: cover;" src=${url} class="h-100 w-100 rounded">
                <span id=${$files[i].name} onclick="removeImage(event)" class="bottom-100  position-relative btn-sm btn btn-danger material-icons">close</span>
            </div>`);
    }
    $('#imageFiles')[0].files = newArray.files;
}

function removeImage(event) {
    let deleteIndex = [...$imageFiles.files].findIndex(x => x.name == event.target.id);
    newArray.items.remove(deleteIndex);
    $imageFiles.files = newArray.files;
    event.target.parentNode.remove();
    imageExist();
}

function removeOldImage(event) {
    imageUrls.push(event.target.id);
    event.target.parentNode.remove();
    imageExist();
}
function validateImage() {
    if (imageExist()) {
        imageUrls.forEach(x => {
            $.get("/User/RemoveImage?url=" + x);
        });
        return true;
    }
    return false;
}

function imageExist() {
    if ($images.children('div').length == 0) {
        $errorText.text("Оголошення має містити принаймні одне зображення");
        return false;
    }
    return true;
}