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

/***/ "./Assets/Dictionary/js/components/dictionaryEditor/index.ts":
/*!*******************************************************************!*\
  !*** ./Assets/Dictionary/js/components/dictionaryEditor/index.ts ***!
  \*******************************************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

eval("__webpack_require__.r(__webpack_exports__);\n/* harmony export */ __webpack_require__.d(__webpack_exports__, {\n/* harmony export */   \"default\": () => (__WEBPACK_DEFAULT_EXPORT__)\n/* harmony export */ });\n/* harmony import */ var vue__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! vue */ \"vue\");\n/* harmony import */ var vue__WEBPACK_IMPORTED_MODULE_0___default = /*#__PURE__*/__webpack_require__.n(vue__WEBPACK_IMPORTED_MODULE_0__);\n\n/* harmony default export */ const __WEBPACK_DEFAULT_EXPORT__ = ((initialData, element, max, min) => {\n    const parsedData = initialData ?\n        initialData.map((i) => ({\n            name: i.Name,\n            value: i.Value\n        })) :\n        [];\n    const focusField = (ref, index) => {\n        const elements = ref;\n        if (index >= elements.length) {\n            return;\n        }\n        const input = elements[index];\n        if (input == null) {\n            return;\n        }\n        input.focus();\n        input.setSelectionRange(input.value.length, input.value.length);\n    };\n    return new (vue__WEBPACK_IMPORTED_MODULE_0___default())({\n        el: element,\n        data: {\n            dictionaryItems: [],\n            maxEntries: max,\n            minEntries: min\n        },\n        computed: {\n            hasEntries() {\n                return this.dictionaryItems.length > 0;\n            },\n            hasMinEntries() {\n                return this.minEntries == null || this.minEntries < 1 || this.dictionaryItems.length >= this.minEntries;\n            },\n            isMaxEntries() {\n                return this.maxEntries != null && this.maxEntries > 0 && this.dictionaryItems.length >= this.maxEntries;\n            },\n            value() {\n                return JSON.stringify(this.dictionaryItems);\n            }\n        },\n        mounted: function () {\n            this.dictionaryItems = parsedData;\n        },\n        methods: {\n            add: function () {\n                if (this.maxEntries && this.dictionaryItems.length >= this.maxEntries) {\n                    return;\n                }\n                this.dictionaryItems.push({ name: '', value: '' });\n                this.$nextTick(() => {\n                    const index = this.dictionaryItems.length - 1;\n                    focusField(this.$refs.name, index);\n                });\n            },\n            handleBackspace: function (ref, index, event) {\n                const value = this.dictionaryItems[index][ref];\n                if (value.length > 0) {\n                    return;\n                }\n                event.preventDefault();\n                if (ref === 'name') {\n                    if (this.dictionaryItems[index].value.length === 0) {\n                        this.remove(index);\n                    }\n                    focusField(this.$refs.value, index - 1);\n                }\n                else {\n                    focusField(this.$refs.name, index);\n                }\n            },\n            handleDown: function (ref, index) {\n                focusField(this.$refs[ref], index + 1);\n            },\n            handleUp: function (ref, index) {\n                focusField(this.$refs[ref], index - 1);\n            },\n            nextField: function (ref, index) {\n                let selectIndex = ref === 'value' ? index + 1 : index;\n                const selectRef = ref === 'value' ? 'name' : 'value';\n                if (ref === 'value' && selectIndex >= this.dictionaryItems.length) {\n                    this.add();\n                    return;\n                }\n                focusField(this.$refs[selectRef], selectIndex);\n            },\n            remove: function (index) {\n                this.dictionaryItems.splice(index, 1);\n            },\n            updatePreview: function () {\n                this.$nextTick(() => {\n                    $(document).trigger('contentpreview:render');\n                });\n            }\n        },\n        watch: {\n            dictionaryItems: function () {\n                this.updatePreview();\n            }\n        }\n    });\n});\n\n\n//# sourceURL=webpack:///./Assets/Dictionary/js/components/dictionaryEditor/index.ts?");

/***/ }),

/***/ "./Assets/Dictionary/js/index.ts":
/*!***************************************!*\
  !*** ./Assets/Dictionary/js/index.ts ***!
  \***************************************/
/***/ ((__unused_webpack_module, __webpack_exports__, __webpack_require__) => {

eval("__webpack_require__.r(__webpack_exports__);\n/* harmony import */ var _components_dictionaryEditor__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./components/dictionaryEditor */ \"./Assets/Dictionary/js/components/dictionaryEditor/index.ts\");\n\nwindow.initializeDictionaryEditor = (el) => {\n    const rawDataInputElement = document.getElementById($(el).data('for'));\n    if (!rawDataInputElement) {\n        return;\n    }\n    const maxEntriesInputElement = document.getElementById($(el).data('max'));\n    const minEntriesInputElement = document.getElementById($(el).data('min'));\n    let max = maxEntriesInputElement ? parseInt(maxEntriesInputElement.value, 10) : undefined;\n    let min = minEntriesInputElement ? parseInt(minEntriesInputElement.value, 10) : undefined;\n    if (typeof (max) !== 'undefined' && isNaN(max)) {\n        max = undefined;\n    }\n    if (typeof (min) !== 'undefined' && isNaN(min)) {\n        min = undefined;\n    }\n    (0,_components_dictionaryEditor__WEBPACK_IMPORTED_MODULE_0__[\"default\"])($(rawDataInputElement).data('init'), el, max, min);\n};\n\n\n//# sourceURL=webpack:///./Assets/Dictionary/js/index.ts?");

/***/ }),

/***/ "vue":
/*!**********************!*\
  !*** external "Vue" ***!
  \**********************/
/***/ ((module) => {

module.exports = Vue;

/***/ })

/******/ 	});
/************************************************************************/
/******/ 	// The module cache
/******/ 	var __webpack_module_cache__ = {};
/******/ 	
/******/ 	// The require function
/******/ 	function __webpack_require__(moduleId) {
/******/ 		// Check if module is in cache
/******/ 		var cachedModule = __webpack_module_cache__[moduleId];
/******/ 		if (cachedModule !== undefined) {
/******/ 			return cachedModule.exports;
/******/ 		}
/******/ 		// Create a new module (and put it into the cache)
/******/ 		var module = __webpack_module_cache__[moduleId] = {
/******/ 			// no module.id needed
/******/ 			// no module.loaded needed
/******/ 			exports: {}
/******/ 		};
/******/ 	
/******/ 		// Execute the module function
/******/ 		__webpack_modules__[moduleId](module, module.exports, __webpack_require__);
/******/ 	
/******/ 		// Return the exports of the module
/******/ 		return module.exports;
/******/ 	}
/******/ 	
/************************************************************************/
/******/ 	/* webpack/runtime/compat get default export */
/******/ 	(() => {
/******/ 		// getDefaultExport function for compatibility with non-harmony modules
/******/ 		__webpack_require__.n = (module) => {
/******/ 			var getter = module && module.__esModule ?
/******/ 				() => (module['default']) :
/******/ 				() => (module);
/******/ 			__webpack_require__.d(getter, { a: getter });
/******/ 			return getter;
/******/ 		};
/******/ 	})();
/******/ 	
/******/ 	/* webpack/runtime/define property getters */
/******/ 	(() => {
/******/ 		// define getter functions for harmony exports
/******/ 		__webpack_require__.d = (exports, definition) => {
/******/ 			for(var key in definition) {
/******/ 				if(__webpack_require__.o(definition, key) && !__webpack_require__.o(exports, key)) {
/******/ 					Object.defineProperty(exports, key, { enumerable: true, get: definition[key] });
/******/ 				}
/******/ 			}
/******/ 		};
/******/ 	})();
/******/ 	
/******/ 	/* webpack/runtime/hasOwnProperty shorthand */
/******/ 	(() => {
/******/ 		__webpack_require__.o = (obj, prop) => (Object.prototype.hasOwnProperty.call(obj, prop))
/******/ 	})();
/******/ 	
/******/ 	/* webpack/runtime/make namespace object */
/******/ 	(() => {
/******/ 		// define __esModule on exports
/******/ 		__webpack_require__.r = (exports) => {
/******/ 			if(typeof Symbol !== 'undefined' && Symbol.toStringTag) {
/******/ 				Object.defineProperty(exports, Symbol.toStringTag, { value: 'Module' });
/******/ 			}
/******/ 			Object.defineProperty(exports, '__esModule', { value: true });
/******/ 		};
/******/ 	})();
/******/ 	
/************************************************************************/
/******/ 	
/******/ 	// startup
/******/ 	// Load entry module and return exports
/******/ 	// This entry module can't be inlined because the eval devtool is used.
/******/ 	var __webpack_exports__ = __webpack_require__("./Assets/Dictionary/js/index.ts");
/******/ 	
/******/ })()
;