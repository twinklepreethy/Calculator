const calculationViewModel = function () {
    var self = this;

    self.minValue = ko.observable();
    self.maxValue = ko.observable();
    self.inputMessage = ko.observable('');
    self.step = ko.observable();
    self.probabilityA = ko.observable();
    self.probabilityB = ko.observable();
    self.functions = ko.observableArray([]);
    self.selectedFunctionId = ko.observable();
    self.showResult = ko.observable(false);
    self.selectedFunction = ko.observable('');
    self.showErrors = ko.observable(false);
    self.errorMessage = ko.observable('');
    self.warningMessage = ko.observable('');
    self.result = ko.observable('');
    self.probabilityAMaxValueErrorMsg = ko.observable('');
    self.probabilityAMinValueErrorMsg = ko.observable('');
    self.probabilityBMaxValueErrorMsg = ko.observable('');
    self.probabilityBMinValueErrorMsg = ko.observable('');
    self.emptyFieldErrorMessage = ko.observable('');
    self.decimalPrecisionWarning = ko.observable('');
    self.resultError = ko.observable('');

    $.ajax({
        url: getApiBaseURL() + '/Calculation/',
        type: 'GET',
        dataType: 'json',
        success: function (result) {
            self.functions(result.functions);
            self.minValue(result.min);
            self.maxValue(result.max);
            self.step(result.step);
            self.probabilityAMaxValueErrorMsg(result.probabilityAMaxValueErrorMsg);
            self.probabilityAMinValueErrorMsg(result.probabilityAMinValueErrorMsg);
            self.probabilityBMaxValueErrorMsg(result.probabilityBMaxValueErrorMsg);
            self.probabilityBMinValueErrorMsg(result.probabilityBMinValueErrorMsg);
            self.emptyFieldErrorMessage(result.emptyFieldErrorMessage);
            self.decimalPrecisionWarning(result.decimalPrecisionWarning);
        },
        error: function (error) {
            self.showErrors(true);
            self.errorMessage(error.responseText);
        }
    });

    $("input").keyup(function () {
        self.clearErrorAndWarnings();
    });

    $("select").click(function () {
        self.clearErrorAndWarnings();
    });

    self.viewResult = function () {
        self.clearErrorAndWarnings();

        if (self.validate()) {

            var selectedFunctionText = $("select option:selected").text();
            self.selectedFunction(selectedFunctionText);

            var data = JSON.stringify({
                SelectedFunctionId: self.selectedFunctionId(),
                ProbabilityA: self.probabilityA(),
                ProbabilityB: self.probabilityB()
            });

            $.ajax({
                url: getApiBaseURL() + '/Calculation/',
                type: 'POST',
                dataType: 'json',
                contentType: 'application/json',
                data: data,
                success: function (result) {
                    self.result(result);
                    self.showResult(true);
                },
                error: function (error) {
                    self.resultError(error.responseText);
                }
            });
        }
        else {
            self.showErrors(true);
        }
    };

    self.validate = function () {

        if (self.probabilityA() == '' || self.probabilityB() == '' || !self.selectedFunctionId()) {
            self.errorMessage(self.emptyFieldErrorMessage());
            return false;
        }

        if (self.probabilityA() > self.maxValue()) {
            self.errorMessage(self.probabilityAMaxValueErrorMsg());
            return false;
        }

        if (self.probabilityB() > self.maxValue()) {
            self.errorMessage(self.probabilityBMaxValueErrorMsg());
            return false;
        }

        if (self.probabilityA() < self.minValue()) {
            self.errorMessage(self.probabilityAMinValueErrorMsg());
            return false;
        }

        if (self.probabilityB() < self.minValue()) {
            self.errorMessage(self.probabilityBMinValueErrorMsg());
            return false;
        }

        var precisionALength = self.probabilityA().includes('.') ? self.probabilityA().split('.')[1].length : 0;
        var precisionBLength = self.probabilityB().includes('.') ? self.probabilityB().split('.')[1].length : 0;
        if (precisionALength > 28 || precisionBLength > 28) {
            self.warningMessage(self.decimalPrecisionWarning());
            return true;
        }

        return true;
    };

    self.clearErrorAndWarnings = function () {
        self.showErrors(false);
        self.warningMessage('');
        self.resultError('');
    };
}

