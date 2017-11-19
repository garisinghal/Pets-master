function GetCatsByOwnerGender(data) {
    var pets = Enumerable.From(data)
        .Where(function (record) { return record.pets !== null; })
        .GroupBy(
            function (a) { return a.gender; },
            function (a) { return { pets: a.pets }; },
            function (key, g) {
                return {
                    gender: key,
                    pets: Enumerable.From(g)
                        .SelectMany(function (a) { return a.pets; })
                        .Where(function (a) { return a.type === 'Cat'; })
                        .OrderBy(function (a) { return a.name; })
                        .ToArray()
                };
            })
        .ToArray();

    return pets; 
};