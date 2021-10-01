/******/ (function(modules) { // webpackBootstrap
/******/ 	// The module cache
/******/ 	var installedModules = {};
/******/
/******/ 	// The require function
/******/ 	function __webpack_require__(moduleId) {
/******/
/******/ 		// Check if module is in cache
/******/ 		if(installedModules[moduleId]) {
/******/ 			return installedModules[moduleId].exports;
/******/ 		}
/******/ 		// Create a new module (and put it into the cache)
/******/ 		var module = installedModules[moduleId] = {
/******/ 			i: moduleId,
/******/ 			l: false,
/******/ 			exports: {}
/******/ 		};
/******/
/******/ 		// Execute the module function
/******/ 		modules[moduleId].call(module.exports, module, module.exports, __webpack_require__);
/******/
/******/ 		// Flag the module as loaded
/******/ 		module.l = true;
/******/
/******/ 		// Return the exports of the module
/******/ 		return module.exports;
/******/ 	}
/******/
/******/
/******/ 	// expose the modules object (__webpack_modules__)
/******/ 	__webpack_require__.m = modules;
/******/
/******/ 	// expose the module cache
/******/ 	__webpack_require__.c = installedModules;
/******/
/******/ 	// define getter function for harmony exports
/******/ 	__webpack_require__.d = function(exports, name, getter) {
/******/ 		if(!__webpack_require__.o(exports, name)) {
/******/ 			Object.defineProperty(exports, name, { enumerable: true, get: getter });
/******/ 		}
/******/ 	};
/******/
/******/ 	// define __esModule on exports
/******/ 	__webpack_require__.r = function(exports) {
/******/ 		if(typeof Symbol !== 'undefined' && Symbol.toStringTag) {
/******/ 			Object.defineProperty(exports, Symbol.toStringTag, { value: 'Module' });
/******/ 		}
/******/ 		Object.defineProperty(exports, '__esModule', { value: true });
/******/ 	};
/******/
/******/ 	// create a fake namespace object
/******/ 	// mode & 1: value is a module id, require it
/******/ 	// mode & 2: merge all properties of value into the ns
/******/ 	// mode & 4: return value when already ns object
/******/ 	// mode & 8|1: behave like require
/******/ 	__webpack_require__.t = function(value, mode) {
/******/ 		if(mode & 1) value = __webpack_require__(value);
/******/ 		if(mode & 8) return value;
/******/ 		if((mode & 4) && typeof value === 'object' && value && value.__esModule) return value;
/******/ 		var ns = Object.create(null);
/******/ 		__webpack_require__.r(ns);
/******/ 		Object.defineProperty(ns, 'default', { enumerable: true, value: value });
/******/ 		if(mode & 2 && typeof value != 'string') for(var key in value) __webpack_require__.d(ns, key, function(key) { return value[key]; }.bind(null, key));
/******/ 		return ns;
/******/ 	};
/******/
/******/ 	// getDefaultExport function for compatibility with non-harmony modules
/******/ 	__webpack_require__.n = function(module) {
/******/ 		var getter = module && module.__esModule ?
/******/ 			function getDefault() { return module['default']; } :
/******/ 			function getModuleExports() { return module; };
/******/ 		__webpack_require__.d(getter, 'a', getter);
/******/ 		return getter;
/******/ 	};
/******/
/******/ 	// Object.prototype.hasOwnProperty.call
/******/ 	__webpack_require__.o = function(object, property) { return Object.prototype.hasOwnProperty.call(object, property); };
/******/
/******/ 	// __webpack_public_path__
/******/ 	__webpack_require__.p = "";
/******/
/******/
/******/ 	// Load entry module and return exports
/******/ 	return __webpack_require__(__webpack_require__.s = "./Assets/Colour/js/index.ts");
/******/ })
/************************************************************************/
/******/ ({

/***/ "./Assets/Colour/js/index.ts":
/*!***********************************!*\
  !*** ./Assets/Colour/js/index.ts ***!
  \***********************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";
eval("\r\nconst CSSClasses = {\r\n    selected: 'is-selected',\r\n};\r\nwindow.initializeColourEditor = (el) => {\r\n    var _a, _b;\r\n    if (!el) {\r\n        return;\r\n    }\r\n    const $hiddenField = el.querySelector('.js-colour-hidden');\r\n    let $selected = el.querySelector('.is-selected');\r\n    const customColourChange = function () {\r\n        if ($hiddenField) {\r\n            $hiddenField.value = this.value;\r\n        }\r\n        setSelected(this);\r\n    };\r\n    const selectColour = function () {\r\n        var _a;\r\n        if ($hiddenField) {\r\n            $hiddenField.value =\r\n                ((_a = this.getAttribute('data-colour')) === null || _a === void 0 ? void 0 : _a.toString()) || '';\r\n        }\r\n        setSelected(this);\r\n    };\r\n    const selectTransparent = function () {\r\n        if ($hiddenField) {\r\n            $hiddenField.value = 'transparent';\r\n        }\r\n        setSelected(this);\r\n    };\r\n    const setSelected = function ($el) {\r\n        if ($selected) {\r\n            $selected.classList.remove(CSSClasses.selected);\r\n        }\r\n        $selected = $el;\r\n        $selected.classList.add(CSSClasses.selected);\r\n        $(document).trigger('contentpreview:render');\r\n    };\r\n    const $colourBtns = el.querySelectorAll('.js-colour-btn');\r\n    for (var i = 0; i < $colourBtns.length; i++) {\r\n        $colourBtns[i].addEventListener('click', selectColour);\r\n    }\r\n    (_a = el.querySelector('.js-transparent-btn')) === null || _a === void 0 ? void 0 : _a.addEventListener('click', selectTransparent);\r\n    (_b = el.querySelector('.js-colour-input')) === null || _b === void 0 ? void 0 : _b.addEventListener('change', customColourChange);\r\n};\r\n\n\n//# sourceURL=webpack:///./Assets/Colour/js/index.ts?");

/***/ })

/******/ });