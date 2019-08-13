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
/******/ 	return __webpack_require__(__webpack_require__.s = "./Assets/Dictionary/js/index.ts");
/******/ })
/************************************************************************/
/******/ ({

/***/ "./Assets/Dictionary/js/components/dictionaryEditor/index.ts":
/*!*******************************************************************!*\
  !*** ./Assets/Dictionary/js/components/dictionaryEditor/index.ts ***!
  \*******************************************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
eval("__webpack_require__.r(__webpack_exports__);\n/* harmony import */ var vue__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! vue */ \"vue\");\n/* harmony import */ var vue__WEBPACK_IMPORTED_MODULE_0___default = /*#__PURE__*/__webpack_require__.n(vue__WEBPACK_IMPORTED_MODULE_0__);\n\r\n/* harmony default export */ __webpack_exports__[\"default\"] = ((initialData, element, max, min) => {\r\n    const parsedData = initialData ?\r\n        initialData.map((i) => ({\r\n            name: i.Name,\r\n            value: i.Value\r\n        })) :\r\n        [];\r\n    const focusField = (ref, index) => {\r\n        const elements = ref;\r\n        if (index >= elements.length) {\r\n            return;\r\n        }\r\n        const input = elements[index];\r\n        if (input == null) {\r\n            return;\r\n        }\r\n        input.focus();\r\n        input.setSelectionRange(input.value.length, input.value.length);\r\n    };\r\n    return new vue__WEBPACK_IMPORTED_MODULE_0___default.a({\r\n        el: element,\r\n        data: {\r\n            dictionaryItems: [],\r\n            maxEntries: max,\r\n            minEntries: min\r\n        },\r\n        computed: {\r\n            hasEntries() {\r\n                return this.dictionaryItems.length > 0;\r\n            },\r\n            hasMinEntries() {\r\n                return this.minEntries == null || this.minEntries < 1 || this.dictionaryItems.length >= this.minEntries;\r\n            },\r\n            isMaxEntries() {\r\n                return this.maxEntries != null && this.maxEntries > 0 && this.dictionaryItems.length >= this.maxEntries;\r\n            },\r\n            value() {\r\n                return JSON.stringify(this.dictionaryItems);\r\n            }\r\n        },\r\n        mounted: function () {\r\n            this.dictionaryItems = parsedData;\r\n        },\r\n        methods: {\r\n            add: function () {\r\n                if (this.maxEntries && this.dictionaryItems.length >= this.maxEntries) {\r\n                    return;\r\n                }\r\n                this.dictionaryItems.push({ name: '', value: '' });\r\n                this.$nextTick(() => {\r\n                    const index = this.dictionaryItems.length - 1;\r\n                    focusField(this.$refs.name, index);\r\n                });\r\n            },\r\n            handleBackspace: function (ref, index, event) {\r\n                const value = this.dictionaryItems[index][ref];\r\n                if (value.length > 0) {\r\n                    return;\r\n                }\r\n                event.preventDefault();\r\n                if (ref === 'name') {\r\n                    if (this.dictionaryItems[index].value.length === 0) {\r\n                        this.remove(index);\r\n                    }\r\n                    focusField(this.$refs.value, index - 1);\r\n                }\r\n                else {\r\n                    focusField(this.$refs.name, index);\r\n                }\r\n            },\r\n            handleDown: function (ref, index) {\r\n                focusField(this.$refs[ref], index + 1);\r\n            },\r\n            handleUp: function (ref, index) {\r\n                focusField(this.$refs[ref], index - 1);\r\n            },\r\n            nextField: function (ref, index) {\r\n                let selectIndex = ref === 'value' ? index + 1 : index;\r\n                const selectRef = ref === 'value' ? 'name' : 'value';\r\n                if (ref === 'value' && selectIndex >= this.dictionaryItems.length) {\r\n                    this.add();\r\n                    return;\r\n                }\r\n                focusField(this.$refs[selectRef], selectIndex);\r\n            },\r\n            remove: function (index) {\r\n                this.dictionaryItems.splice(index, 1);\r\n            },\r\n            updatePreview: function () {\r\n                this.$nextTick(() => {\r\n                    $(document).trigger('contentpreview:render');\r\n                });\r\n            }\r\n        },\r\n        watch: {\r\n            dictionaryItems: function () {\r\n                this.updatePreview();\r\n            }\r\n        }\r\n    });\r\n});\r\n\n\n//# sourceURL=webpack:///./Assets/Dictionary/js/components/dictionaryEditor/index.ts?");

/***/ }),

/***/ "./Assets/Dictionary/js/index.ts":
/*!***************************************!*\
  !*** ./Assets/Dictionary/js/index.ts ***!
  \***************************************/
/*! no exports provided */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
eval("__webpack_require__.r(__webpack_exports__);\n/* harmony import */ var _components_dictionaryEditor__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./components/dictionaryEditor */ \"./Assets/Dictionary/js/components/dictionaryEditor/index.ts\");\n\r\nwindow.initializeDictionaryEditor = (el) => {\r\n    const rawDataInputElement = document.getElementById($(el).data('for'));\r\n    if (!rawDataInputElement) {\r\n        return;\r\n    }\r\n    const maxEntriesInputElement = document.getElementById($(el).data('max'));\r\n    const minEntriesInputElement = document.getElementById($(el).data('min'));\r\n    let max = maxEntriesInputElement ? parseInt(maxEntriesInputElement.value, 10) : undefined;\r\n    let min = minEntriesInputElement ? parseInt(minEntriesInputElement.value, 10) : undefined;\r\n    if (typeof (max) !== 'undefined' && isNaN(max)) {\r\n        max = undefined;\r\n    }\r\n    if (typeof (min) !== 'undefined' && isNaN(min)) {\r\n        min = undefined;\r\n    }\r\n    Object(_components_dictionaryEditor__WEBPACK_IMPORTED_MODULE_0__[\"default\"])($(rawDataInputElement).data('init'), el, max, min);\r\n};\r\n\n\n//# sourceURL=webpack:///./Assets/Dictionary/js/index.ts?");

/***/ }),

/***/ "vue":
/*!**********************!*\
  !*** external "Vue" ***!
  \**********************/
/*! no static exports found */
/***/ (function(module, exports) {

eval("module.exports = Vue;\n\n//# sourceURL=webpack:///external_%22Vue%22?");

/***/ })

/******/ });