/*
 * ATTENTION: The "eval" devtool has been used (maybe by default in mode: "development").
 * This devtool is neither made for production nor for readable output files.
 * It uses "eval()" calls to create a separate source file in the browser devtools.
 * If you are trying to read the output file, select a different devtool (https://webpack.js.org/configuration/devtool/)
 * or disable the default devtool with "devtool: false".
 * If you are looking for production-ready output files, see mode: "production" (https://webpack.js.org/configuration/mode/).
 */
/******/ (() => { // webpackBootstrap
/******/ 	"use strict";
/******/ 	var __webpack_modules__ = ({

/***/ "./Assets/Colour/js/index.ts":
/*!***********************************!*\
  !*** ./Assets/Colour/js/index.ts ***!
  \***********************************/
/***/ (() => {

eval("\nconst CSSClasses = {\n    selected: 'is-selected',\n};\nwindow.initializeColourEditor = (el) => {\n    var _a, _b;\n    if (!el) {\n        return;\n    }\n    const $hiddenField = el.querySelector('.js-colour-hidden');\n    let $selected = el.querySelector('.is-selected');\n    const customColourChange = function () {\n        if ($hiddenField) {\n            $hiddenField.value = this.value;\n        }\n        setSelected(this);\n    };\n    const selectColour = function () {\n        var _a;\n        if ($hiddenField) {\n            $hiddenField.value =\n                ((_a = this.getAttribute('data-colour')) === null || _a === void 0 ? void 0 : _a.toString()) || '';\n        }\n        setSelected(this);\n    };\n    const selectTransparent = function () {\n        if ($hiddenField) {\n            $hiddenField.value = 'transparent';\n        }\n        setSelected(this);\n    };\n    const setSelected = function ($el) {\n        if ($selected) {\n            $selected.classList.remove(CSSClasses.selected);\n        }\n        $selected = $el;\n        $selected.classList.add(CSSClasses.selected);\n        $(document).trigger('contentpreview:render');\n    };\n    const $colourBtns = el.querySelectorAll('.js-colour-btn');\n    for (var i = 0; i < $colourBtns.length; i++) {\n        $colourBtns[i].addEventListener('click', selectColour);\n    }\n    (_a = el.querySelector('.js-transparent-btn')) === null || _a === void 0 ? void 0 : _a.addEventListener('click', selectTransparent);\n    (_b = el.querySelector('.js-colour-input')) === null || _b === void 0 ? void 0 : _b.addEventListener('change', customColourChange);\n};\n\n\n//# sourceURL=webpack:///./Assets/Colour/js/index.ts?");

/***/ })

/******/ 	});
/************************************************************************/
/******/ 	
/******/ 	// startup
/******/ 	// Load entry module and return exports
/******/ 	// This entry module can't be inlined because the eval devtool is used.
/******/ 	var __webpack_exports__ = {};
/******/ 	__webpack_modules__["./Assets/Colour/js/index.ts"]();
/******/ 	
/******/ })()
;