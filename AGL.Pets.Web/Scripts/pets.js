$(document).ready(function () {
    var url = "http://agl-developer-test.azurewebsites.net/people.json";
    $.ajax({
        url: url,
        data: { format: 'json' },
        dataType: 'jsonp',
        type: 'GET'
    })
    .done(function (data) {
        var pets = GetCatsByOwnerGender(data);
        RenderPets(pets);
    })
    .fail(function (e) {
        console.log(e);
    });
});

function RenderPets(items) {
    var element = document.getElementById('container');
    items.forEach(function (item) {
        var ul = document.createElement('ul');
        ul.textContent = item.gender + ' (owners)';
        element.appendChild(ul);

        item.pets.forEach(function (pet) {
            var ul = document.createElement('ul');
            ul.innerHTML = pet.name;
            ul.style.marginLeft = '30px';
            element.appendChild(ul);
        });

    }); 
}