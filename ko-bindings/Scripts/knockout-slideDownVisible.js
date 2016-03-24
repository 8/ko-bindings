(function () {
  "use strict";

  ko.bindingHandlers.slideDownVisible = {
    init: function (element, valueAccessor) {
      var value = valueAccessor();
      $(element).toggle(ko.unwrap(value));
    },
    update: function (element, valueAccessor) {
      var value = valueAccessor();
      ko.unwrap(value) ? $(element).slideDown() : $(element).slideUp();
    }
  };

}());