
$storage = window.sessionStorage;
$count_header = $('#count-header');
$content = $('#content');

if (!$storage.getItem("Partial")) {
	$storage.setItem("Partial", "_ShowAdvertsPartial");
	$storage.setItem("FindCity", "Всі міста");
	$storage.setItem("FindStr", "");
	resetFilter();
}

load();

$('#confirm-filter').click(() => {
	$category = $('#filter-category').val();
	$state = $('input[name=btnradio]:checked').val();
	$price_from = $('#price-from').val();
	$price_to = $('#price-to').val();
	$storage.setItem("Category", $category);
	$storage.setItem("State", $state);
	$storage.setItem("PriceFrom", $price_from);
	$storage.setItem("PriceTo", $price_to);
	setContent($partial);
});

$('#list-show').click(() => setContent("_ShowAdvertsPartial"));

$('#module-show').click(() => setContent("_ShowAdvertsDashboardPartial"));

$('#title-sort').click(() => {
	$sort = "title";
	setContent($partial);
});

$('#date-sort').click(() => {
	$sort = "date";
	setContent($partial);
});

$('#find-button').click(() => {

	$storage.setItem("FindStr", $('#find-str').val());
	$storage.setItem("FindCity", $('#find-city').val());
	resetFilter();
	load();
});

function resetFilter() {
	$storage.setItem("Category", "Всі категорії");
	$storage.setItem("State", "all");
	$storage.setItem("PriceFrom", '');
	$storage.setItem("PriceTo", '');
}

function load() {
	$find_str = $storage.getItem("FindStr");
	$find_city = $storage.getItem("FindCity");
	$sort = $storage.getItem("Sort");
	$partial = $storage.getItem("Partial");
	$category = $storage.getItem("Category");
	$state = $storage.getItem("State");
	$price_from = $storage.getItem("PriceFrom");
	$price_to = $storage.getItem("PriceTo");
	$('#filter-category').val($category);
	$(`input:radio[id=${$state}]`).prop('checked', true);
	$('#price-from').val($price_from);
	$('#price-to').val($price_to);
	$('#find-str').val($find_str);
	$('#find-city').val($find_city);
	setContent($partial);
}

function setContent(partial) {
	$partial = partial;
	$storage.setItem("Partial", partial);
	$storage.setItem("Sort", $sort);

	$.get(`/Home/AdvertPartial?partial=${partial}&sort=${$sort}&category=${$category}&state=${$state}&from=${$price_from}&to=${$price_to}&find=${$find_str}&fcity=${$find_city}`).done((res) => {
		$content.empty();
		$content.html(res);
		$el_count = $('#element-count').val();
		$count_header.text($el_count == 0 ? "Не знайдено жодного оголошення" : `Знайдено ${$el_count} позицій`);
	}).fail((info) => console.info(info.responseText));
}