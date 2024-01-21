const newArray = new DataTransfer();
function displayNames(event) {
    $files = event.files;
    $imageContainer = $('#imageContainer > div');
    for (let i = 0; i < $files.length; i++) {
        newArray.items.add($files[i]);
        let url = URL.createObjectURL($files[i]);
        $imageContainer.append(`
                                    <div class="my-2"style="height:140px;width:200px;">
                                        <img style="object-fit: cover;" src=${url} class="h-100 w-100 rounded">
                                        <span id=${$files[i].name} onclick="removeImage(event)" class="bottom-100  position-relative btn-sm btn btn-danger material-icons">close</span>
                                    </div>`);
    }
    $('#imageFiles')[0].files = newArray.files;
}

function removeImage(event) {
    $imageFiles = $('#imageFiles')[0];
    let deleteIndex = [...$imageFiles.files].findIndex(x => x.name == event.target.id);
    newArray.items.remove(deleteIndex);
    $imageFiles.files = newArray.files;
    event.target.parentNode.remove();
}

function removeOldImage(event) {
    $.get("/User/RemoveImageUrl?url=" + event.target.id, function (res) {
        if (res) event.target.parentNode.remove();
    });
}