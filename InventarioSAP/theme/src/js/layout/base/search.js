"use strict";

var KTLayoutSearch = function() {
    // Private properties
    var _modalElement;

    var _initModal = function() {
        _modalElement.addEventListener('shown.bs.modal', function () {
            _modalElement.querySelector('[autofocus]').focus();
        });
    }

    // Public Methods
	return {
		init: function() {
            _modalElement = document.querySelector('#kt_header_search_modal');

            if (_modalElement) {
                _initModal();
            }
		}
	};
}();

// On document ready
KTUtil.onDOMContentLoaded(function() {
    KTLayoutSearch.init();
});

// Webpack support
if (typeof module !== 'undefined' && typeof module.exports !== 'undefined') {
    module.exports = KTLayoutSearch;
}