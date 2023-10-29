// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

let WeatherFunction = (() => {
    var token = '';
    return {
        Init: (() => {
            $('#cbCountry').select2({
                theme: 'bootstrap-5',
                width: '100%',
                placeholder: 'Select Country',
                ajax: {
                    url: "/Home/GetCountry",
                    type: "POST",
                    dataType: 'json',
                    delay: 0,
                    processResults: function (data) {
                        return {
                            results: $.map(data, function (item) {
                                return {
                                    text: item.text,
                                    id: item.value
                                }
                            })
                        };
                    },
                    cache: true
                }
            });

            $('#cbCountry').on('select2:select', function (e) {
                var dataParam = e.params.data;

                $('#cbCity').select2({
                    width: '100%',
                    allowClear: true,
                    placeholder: 'Select City',
                    theme: 'bootstrap-5',
                    ajax: {
                        url: "/Home/GetCity",
                        type: "POST",
                        data: function (params) {

                            var queryParameters = {
                                term: params.term,
                                countryCode: dataParam.id,
                                countrySearch: params.term
                            }
                            return queryParameters;
                        },
                        //data: { countryCode: data.id },
                        dataType: 'json',
                        delay: 0,
                        processResults: function (data) {
                            return {
                                results: $.map(data, function (item) {
                                    return {
                                        text: item.text,
                                        id: item.value
                                    }
                                })
                            };
                        },
                        cache: true
                    }
                });
            });
        }),
        GetWeather: (() => {
            var searchParameter = new FormData();
            searchParameter.append("CountryCode", $('#cbCountry').val());
            searchParameter.append("City", $('#cbCity').val());

            $.ajax({
                type: "POST",
                url:'/Home/GetWeather',
                data: searchParameter,
                contentType: false,
                processData: false,
                success: function (objRes) {
                    if (objRes.status === false) {
                        alert(objRes.message)
                    } else {
                        WeatherFunction.BindWeather(objRes.entity);
                    }
                },
                error: function (response) {
                    console.log(response);
                    alert('Error function please contact developer');
                }
            });
        }),
        BindWeather: ((entity) => {
            if (entity !== null && entity !== undefined) {
                console.log(entity);
                $('#tbLocation').val(entity.coord.lon + " - " + entity.coord.lat);
                $('#tbTime').val(entity.time);
                $('#tbWind').val(entity.wind.speed + " - " + entity.wind.deg);
                $('#tbVisibility').val(entity.visibility);
                $('#tbSkyConditions').val('Dont know what should be mapped');
                $('#tbVisibility').val(entity.visibility);
                $('#tbTemperaturCelcius').val(entity.main.tempCelcius);
                $('#tbTemperaturFahrenheit').val(entity.main.temp);
                $('#tbRelativeHumidity').val(entity.main.humidity);
                $('#tbPressure').val(entity.main.pressure);
                $('#tbDewPoint').val('Invalid API key. Onecall is not available for free version. https://api.openweathermap.org/data/2.5/onecall');
            }
        }),
    }
})();