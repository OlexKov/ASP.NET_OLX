$('list-show').on("click",()=>setContent("_ShowAdvertsPartial"));
$('module-show').on("click", () => { setContent("_ShowAdvertsDashboardPartial") });


$content = $('#content');
$localStorage = window.localStorage;
$partial = "_ShowAdvertsPartial";

if (!$localStorage.getItem("Partial")) {
	$localStorage.setItem("Partial", partial);
	setContent($partial);
}
else {
	$partial = $localStorage.getItem("Partial");
	setContent($partial);
}

function setContent(partial) {
	$localStorage.setItem("Partial", partial);
	$.get("/Home/AdvertPartial?partial=" + partial).done((res) => {
		$content.empty();
		$content.html(res)
	})
}