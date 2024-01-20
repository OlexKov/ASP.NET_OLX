function displayNames(event) {
    $files = event.files;
    $imageContainer = $('#imageContainer > div');
    $imageContainer.empty();
    for (let i = 0; i < $files.length; i++) {
        let url = URL.createObjectURL($files[i]);
        $imageContainer.append(`
                                <div class="my-2"style="height:140px;width:200px;">
                                    <img style="object-fit: cover;" src=${url} class="h-100 w-100 rounded">
                                    <span id=${$files[i].name} onclick="removeImage(event)" class="bottom-100  position-relative btn-sm btn btn-danger material-icons">close</span>
                                </div>`);
    }
}

function removeImage(event) {
    $imageFiles = $('#imageFiles')[0];
    const newArray = new DataTransfer();
    for (let i = 0; i < $imageFiles.files.length; i++) {
        if ($imageFiles.files[i].name != event.target.id) {
            newArray.items.add($imageFiles.files[i]);
        }
    }
    $imageFiles.files = newArray.files;
    event.target.parentNode.remove();
}