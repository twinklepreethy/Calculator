const calculationViewModel = function () {
    var self = this;

    self.minValue = ko.observable();
    self.maxValue = ko.observable();
    self.inputMessage = ko.observable('');
    self.step = ko.observable();
    self.probabilityA = ko.observable();
    self.probabilityB = ko.observable();
    self.isClicked = ko.observable(false);

    self.onFunctionClick = function () {
        self.isClicked(true);

        $($(this)[0]).removeClass('btn-primary');
        $($(this)[0]).addClass('btn-secondary');
        var buttons = document.querySelectorAll('button');
        ko.utils.arrayForEach(buttons, function (button) {
            var buttonViewModel = ko.contextFor(button).$data;
            if (button !== $(this)[0]) {
                buttonViewModel.isClicked(false);

                if (!$(button).hasClass('btn-primary')) {
                    $(button).addClass('btn-primary');
                    $(button).removeClass('btn-secondary');
                }
            }
        });
    };
}

