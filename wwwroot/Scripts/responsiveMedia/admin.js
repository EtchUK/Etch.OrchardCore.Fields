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
/******/ 	return __webpack_require__(__webpack_require__.s = "./Assets/ResponsiveMedia/js/index.ts");
/******/ })
/************************************************************************/
/******/ ({

/***/ "./Assets/ResponsiveMedia/js/components/responsiveMediaEditor/components/responsiveMediaItem/index.ts":
/*!************************************************************************************************************!*\
  !*** ./Assets/ResponsiveMedia/js/components/responsiveMediaEditor/components/responsiveMediaItem/index.ts ***!
  \************************************************************************************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
eval("__webpack_require__.r(__webpack_exports__);\n/* harmony import */ var vue__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! vue */ \"vue\");\n/* harmony import */ var vue__WEBPACK_IMPORTED_MODULE_0___default = /*#__PURE__*/__webpack_require__.n(vue__WEBPACK_IMPORTED_MODULE_0__);\n/* harmony import */ var _models_mediaItem__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../../models/mediaItem */ \"./Assets/ResponsiveMedia/js/components/responsiveMediaEditor/models/mediaItem.ts\");\n\r\n\r\n/* harmony default export */ __webpack_exports__[\"default\"] = (vue__WEBPACK_IMPORTED_MODULE_0___default.a.extend({\r\n    name: 'responsiveMediaItem',\r\n    props: {\r\n        breakpoints: Array,\r\n        media: _models_mediaItem__WEBPACK_IMPORTED_MODULE_1__[\"default\"],\r\n    },\r\n    data: function () {\r\n        return {\r\n            selectedBreakpoint: 0,\r\n        };\r\n    },\r\n    computed: {\r\n        activeBreakpoint() {\r\n            if (this.selectedBreakpoint > 0) {\r\n                return this.selectedBreakpoint;\r\n            }\r\n            return this.media.getLargestBreakpoint();\r\n        },\r\n        activeName() {\r\n            const source = this.media.getSourceAt(this\r\n                .activeBreakpoint);\r\n            if (source === null) {\r\n                const alternateSource = this\r\n                    .media.getSourceOrAlternative(this\r\n                    .activeBreakpoint);\r\n                return alternateSource\r\n                    ? `Auto generated by ${alternateSource.breakpoint}`\r\n                    : 'N/A';\r\n            }\r\n            return source.name;\r\n        },\r\n        isOnlySmallImage() {\r\n            return this.media.sources.length === 1 && this.media.sources[0].breakpoint === 0;\r\n        },\r\n        url() {\r\n            return this.media.getUrlAt(this\r\n                .activeBreakpoint);\r\n        },\r\n    },\r\n    methods: {\r\n        hasNoSource(breakpoint) {\r\n            return !this.media.hasSource(breakpoint);\r\n        },\r\n        remove() {\r\n            this.$emit('remove', {\r\n                media: this.media,\r\n            });\r\n        },\r\n        removeBreakpoint() {\r\n            if (this.media.removeBreakpoint(this.activeBreakpoint)) {\r\n                this.remove();\r\n            }\r\n        },\r\n        update() {\r\n            this.$emit('update', {\r\n                media: this.media,\r\n                breakpoint: this.activeBreakpoint,\r\n            });\r\n        },\r\n    },\r\n    template: `<div class=\"card\">\r\n        <img :src=\"url\" class=\"card-img-top\" alt=\"\" />\r\n        <div class=\"card-body flex-column\">\r\n            <p class=\"small\">{{ activeName }} {{ isOnlySmallImage }}</p>\r\n\r\n            <div class=\"d-flex flex-row flex-wrap mb-1\">\r\n                <button \r\n                    v-for=\"breakpoint in breakpoints\" \r\n                    type=\"button\" \r\n                    class=\"btn btn-secondary btn-sm mb-1 mr-1\" \r\n                    v-on:click=\"selectedBreakpoint = breakpoint\" \r\n                    v-bind:class=\"{ active: activeBreakpoint == breakpoint, 'btn-warning': hasNoSource(breakpoint) }\">\r\n                    {{ breakpoint }}\r\n                </button>\r\n            </div>\r\n\r\n            <div v-bind:class=\"{ 'd-none': isOnlySmallImage }\">\r\n                <div \r\n                    class=\"d-flex flex-row flex-wrap mb-2\"\r\n                    v-bind:class=\"{ 'display-none': !isOnlySmallImage }\">\r\n                    <a href=\"#\" class=\"mr-3\" v-on:click.prevent=\"update\">Change image at {{ activeBreakpoint }}</a>\r\n                </div>\r\n            </div>\r\n\r\n            <div \r\n                class=\"d-none\"\r\n                v-bind:class=\"{ 'd-block': isOnlySmallImage }\">\r\n                <div \r\n                    class=\"d-flex flex-row flex-wrap mb-2\">\r\n                    <p class=\"small mb-1\"><em>Image is smaller than smallest breakpoint</em></p>\r\n                </div>\r\n            </div>\r\n\r\n            <div class=\"btn-group\">\r\n                <button type=\"button\" title=\"Remove Options\" class=\"btn btn-danger btn-sm dropdown-toggle\" data-toggle=\"dropdown\" aria-haspopup=\"true\" aria-expanded=\"false\">\r\n                    <svg class=\"svg-inline--fa fa-trash-alt fa-w-14\" aria-hidden=\"true\" focusable=\"false\" data-prefix=\"fa\" data-icon=\"trash-alt\" role=\"img\" xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 448 512\" data-fa-i2svg=\"\"><path fill=\"currentColor\" d=\"M32 464a48 48 0 0 0 48 48h288a48 48 0 0 0 48-48V128H32zm272-256a16 16 0 0 1 32 0v224a16 16 0 0 1-32 0zm-96 0a16 16 0 0 1 32 0v224a16 16 0 0 1-32 0zm-96 0a16 16 0 0 1 32 0v224a16 16 0 0 1-32 0zM432 32H312l-9.4-18.7A24 24 0 0 0 281.1 0H166.8a23.72 23.72 0 0 0-21.4 13.3L136 32H16A16 16 0 0 0 0 48v32a16 16 0 0 0 16 16h416a16 16 0 0 0 16-16V48a16 16 0 0 0-16-16z\"></path></svg>\r\n                </button>\r\n                <div class=\"dropdown-menu\">\r\n                    <a class=\"dropdown-item btn-sm\" v-on:click.prevent=\"removeBreakpoint\">Remove at {{ activeBreakpoint }}</a>\r\n                    <a class=\"dropdown-item btn-sm\" v-on:click.prevent=\"remove\">Remove</a>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>`,\r\n}));\r\n\n\n//# sourceURL=webpack:///./Assets/ResponsiveMedia/js/components/responsiveMediaEditor/components/responsiveMediaItem/index.ts?");

/***/ }),

/***/ "./Assets/ResponsiveMedia/js/components/responsiveMediaEditor/index.ts":
/*!*****************************************************************************!*\
  !*** ./Assets/ResponsiveMedia/js/components/responsiveMediaEditor/index.ts ***!
  \*****************************************************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
eval("__webpack_require__.r(__webpack_exports__);\n/* harmony import */ var bootstrap__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! bootstrap */ \"bootstrap\");\n/* harmony import */ var bootstrap__WEBPACK_IMPORTED_MODULE_0___default = /*#__PURE__*/__webpack_require__.n(bootstrap__WEBPACK_IMPORTED_MODULE_0__);\n/* harmony import */ var jquery__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! jquery */ \"jquery\");\n/* harmony import */ var jquery__WEBPACK_IMPORTED_MODULE_1___default = /*#__PURE__*/__webpack_require__.n(jquery__WEBPACK_IMPORTED_MODULE_1__);\n/* harmony import */ var vue__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! vue */ \"vue\");\n/* harmony import */ var vue__WEBPACK_IMPORTED_MODULE_2___default = /*#__PURE__*/__webpack_require__.n(vue__WEBPACK_IMPORTED_MODULE_2__);\n/* harmony import */ var _components_responsiveMediaItem__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./components/responsiveMediaItem */ \"./Assets/ResponsiveMedia/js/components/responsiveMediaEditor/components/responsiveMediaItem/index.ts\");\n/* harmony import */ var _utils_createMediaItem__WEBPACK_IMPORTED_MODULE_4__ = __webpack_require__(/*! ./utils/createMediaItem */ \"./Assets/ResponsiveMedia/js/components/responsiveMediaEditor/utils/createMediaItem.ts\");\n/* harmony import */ var _utils_parseFieldValue__WEBPACK_IMPORTED_MODULE_5__ = __webpack_require__(/*! ./utils/parseFieldValue */ \"./Assets/ResponsiveMedia/js/components/responsiveMediaEditor/utils/parseFieldValue.ts\");\nvar __awaiter = (undefined && undefined.__awaiter) || function (thisArg, _arguments, P, generator) {\r\n    return new (P || (P = Promise))(function (resolve, reject) {\r\n        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }\r\n        function rejected(value) { try { step(generator[\"throw\"](value)); } catch (e) { reject(e); } }\r\n        function step(result) { result.done ? resolve(result.value) : new P(function (resolve) { resolve(result.value); }).then(fulfilled, rejected); }\r\n        step((generator = generator.apply(thisArg, _arguments || [])).next());\r\n    });\r\n};\r\n\r\n\r\n\r\n\r\n\r\n\r\nconst selectors = {\r\n    mediaApp: '#mediaApp',\r\n    mediaFieldSelectButton: '.mediaFieldSelectButton',\r\n    modalBody: '.modal-body',\r\n};\r\n/* harmony default export */ __webpack_exports__[\"default\"] = ((el, initialData, modalBodyElement, breakpoints, isMultiple) => {\r\n    return new vue__WEBPACK_IMPORTED_MODULE_2___default.a({\r\n        el,\r\n        data: {\r\n            breakpoints,\r\n            isMultiple,\r\n            mediaItems: [],\r\n        },\r\n        components: {\r\n            ResponsiveMediaItem: _components_responsiveMediaItem__WEBPACK_IMPORTED_MODULE_3__[\"default\"],\r\n        },\r\n        computed: {\r\n            canAdd() {\r\n                return this.isMultiple || this.mediaItems.length === 0;\r\n            },\r\n            hasMedia() {\r\n                return this.mediaItems.length > 0;\r\n            },\r\n            value() {\r\n                return JSON.stringify(this.mediaItems.map((x) => {\r\n                    return {\r\n                        sources: x.sources.map((source) => {\r\n                            return {\r\n                                breakpoint: source.breakpoint,\r\n                                path: source.path,\r\n                            };\r\n                        }),\r\n                    };\r\n                }));\r\n            },\r\n        },\r\n        mounted: function () {\r\n            this.mediaItems = Object(_utils_parseFieldValue__WEBPACK_IMPORTED_MODULE_5__[\"default\"])(initialData);\r\n        },\r\n        methods: {\r\n            add: function () {\r\n                const self = this;\r\n                jquery__WEBPACK_IMPORTED_MODULE_1___default()(selectors.mediaApp)\r\n                    .detach()\r\n                    .appendTo(jquery__WEBPACK_IMPORTED_MODULE_1___default()(modalBodyElement).find(selectors.modalBody));\r\n                jquery__WEBPACK_IMPORTED_MODULE_1___default()(selectors.mediaApp).show();\r\n                const modal = jquery__WEBPACK_IMPORTED_MODULE_1___default()(modalBodyElement).modal();\r\n                jquery__WEBPACK_IMPORTED_MODULE_1___default()(modalBodyElement)\r\n                    .find(selectors.mediaFieldSelectButton)\r\n                    .off('click')\r\n                    .on('click', function () {\r\n                    return __awaiter(this, void 0, void 0, function* () {\r\n                        if (window.mediaApp.selectedMedias.length) {\r\n                            self.mediaItems.push(yield Object(_utils_createMediaItem__WEBPACK_IMPORTED_MODULE_4__[\"default\"])(self.breakpoints, window.mediaApp.selectedMedias));\r\n                        }\r\n                        window.mediaApp.selectedMedias = [];\r\n                        modal.modal('hide');\r\n                        return true;\r\n                    });\r\n                });\r\n            },\r\n            remove: function (args) {\r\n                this.mediaItems.splice(this.mediaItems.indexOf(args.media), 1);\r\n            },\r\n            update: function (args) {\r\n                jquery__WEBPACK_IMPORTED_MODULE_1___default()(selectors.mediaApp)\r\n                    .detach()\r\n                    .appendTo(jquery__WEBPACK_IMPORTED_MODULE_1___default()(modalBodyElement).find(selectors.modalBody));\r\n                jquery__WEBPACK_IMPORTED_MODULE_1___default()(selectors.mediaApp).show();\r\n                const modal = jquery__WEBPACK_IMPORTED_MODULE_1___default()(modalBodyElement).modal();\r\n                jquery__WEBPACK_IMPORTED_MODULE_1___default()(modalBodyElement)\r\n                    .find(selectors.mediaFieldSelectButton)\r\n                    .off('click')\r\n                    .on('click', function () {\r\n                    return __awaiter(this, void 0, void 0, function* () {\r\n                        if (window.mediaApp.selectedMedias.length) {\r\n                            args.media.addSource(args.breakpoint, window.mediaApp.selectedMedias[0]);\r\n                        }\r\n                        window.mediaApp.selectedMedias = [];\r\n                        modal.modal('hide');\r\n                        return true;\r\n                    });\r\n                });\r\n            },\r\n            updatePreview: function () {\r\n                this.$nextTick(() => {\r\n                    jquery__WEBPACK_IMPORTED_MODULE_1___default()(document).trigger('contentpreview:render');\r\n                });\r\n            },\r\n        },\r\n        watch: {\r\n            mediaItems: function () {\r\n                this.updatePreview();\r\n            },\r\n        },\r\n    });\r\n});\r\n\n\n//# sourceURL=webpack:///./Assets/ResponsiveMedia/js/components/responsiveMediaEditor/index.ts?");

/***/ }),

/***/ "./Assets/ResponsiveMedia/js/components/responsiveMediaEditor/models/mediaItem.ts":
/*!****************************************************************************************!*\
  !*** ./Assets/ResponsiveMedia/js/components/responsiveMediaEditor/models/mediaItem.ts ***!
  \****************************************************************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
eval("__webpack_require__.r(__webpack_exports__);\n/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, \"default\", function() { return MediaItem; });\n/* harmony import */ var _mediaSource__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./mediaSource */ \"./Assets/ResponsiveMedia/js/components/responsiveMediaEditor/models/mediaSource.ts\");\n/* harmony import */ var _utils_sortUtils__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../utils/sortUtils */ \"./Assets/ResponsiveMedia/js/components/responsiveMediaEditor/utils/sortUtils.ts\");\n\r\n\r\nclass MediaItem {\r\n    constructor(source) {\r\n        this.sources = source || new Array();\r\n    }\r\n    /**\r\n     * Adds a new image source for a breakpoint.\r\n     */\r\n    addSource(breakpoint, media) {\r\n        let existingSource = null;\r\n        for (let i = 0; i < this.sources.length; i++) {\r\n            if (this.sources[i].breakpoint === breakpoint) {\r\n                existingSource = this.sources[i];\r\n                break;\r\n            }\r\n        }\r\n        if (existingSource !== null) {\r\n            existingSource.name = media.name;\r\n            existingSource.path = media.path;\r\n            existingSource.url = media.url;\r\n            return;\r\n        }\r\n        this.sources.push(new _mediaSource__WEBPACK_IMPORTED_MODULE_0__[\"default\"](breakpoint, media.name, media.mediaPath, media.url));\r\n    }\r\n    /**\r\n     * Returns list of breakpoints associated to sources.\r\n     */\r\n    getBreakpoints() {\r\n        return this.sources.map(x => x.breakpoint);\r\n    }\r\n    /**\r\n     * Gets the largest breakpoint associated to sources.\r\n     */\r\n    getLargestBreakpoint() {\r\n        let largestBreakpoint = 0;\r\n        for (let i = 0; i < this.sources.length; i++) {\r\n            if (this.sources[i].breakpoint > largestBreakpoint) {\r\n                largestBreakpoint = this.sources[i].breakpoint;\r\n            }\r\n        }\r\n        return largestBreakpoint;\r\n    }\r\n    /**\r\n     * Returns the source associated to the provided breakpoint. If\r\n     * one isn't found then `null` is returned.\r\n     */\r\n    getSourceAt(breakpoint) {\r\n        if (!this.sources || !this.sources.length) {\r\n            return null;\r\n        }\r\n        let matchingSource = this.sources.find(value => {\r\n            return value.breakpoint === breakpoint;\r\n        });\r\n        return matchingSource || null;\r\n    }\r\n    /**\r\n     * Returns the source associated to the provided breakpoint. If\r\n     * one isn't defined, the source associated to the next largest\r\n     * breakpoint will be returned. If there isn't a source defined\r\n     * for a larger breakpoint, then `null` is returned.\r\n     */\r\n    getSourceOrAlternative(breakpoint) {\r\n        const matchingSource = this.getSourceAt(breakpoint);\r\n        if (matchingSource) {\r\n            return matchingSource;\r\n        }\r\n        const breakpoints = Object(_utils_sortUtils__WEBPACK_IMPORTED_MODULE_1__[\"sortNumbers\"])(this.getBreakpoints());\r\n        for (var i = 0; i < breakpoints.length; i++) {\r\n            if (breakpoints[i] < breakpoint) {\r\n                continue;\r\n            }\r\n            return this.getSourceAt(breakpoints[i]);\r\n        }\r\n        return null;\r\n    }\r\n    /**\r\n     * Returns URL for source associated to provided breakpoint. If no source\r\n     * matches the breakpoint then the resized URL for the next largest breakpoint\r\n     * will be returned. When there isn't a larger breakpoint, an empty string\r\n     * is returned.\r\n     */\r\n    getUrlAt(breakpoint) {\r\n        const matchingSource = this.getSourceAt(breakpoint);\r\n        if (!matchingSource) {\r\n            const alternateSource = this.getSourceOrAlternative(breakpoint);\r\n            return alternateSource\r\n                ? `${alternateSource.url}?width=${breakpoint}`\r\n                : '';\r\n        }\r\n        return matchingSource.url;\r\n    }\r\n    /**\r\n     * Returns whether there is a source for the provided breakpoint.\r\n     */\r\n    hasSource(breakpoint) {\r\n        return this.getSourceAt(breakpoint) !== null;\r\n    }\r\n    removeBreakpoint(breakpoint) {\r\n        let matchingSource = this.getSourceAt(breakpoint);\r\n        if (matchingSource) {\r\n            this.sources.splice(this.sources.indexOf(matchingSource), 1);\r\n        }\r\n        return this.sources.length === 0;\r\n    }\r\n}\r\n\n\n//# sourceURL=webpack:///./Assets/ResponsiveMedia/js/components/responsiveMediaEditor/models/mediaItem.ts?");

/***/ }),

/***/ "./Assets/ResponsiveMedia/js/components/responsiveMediaEditor/models/mediaSource.ts":
/*!******************************************************************************************!*\
  !*** ./Assets/ResponsiveMedia/js/components/responsiveMediaEditor/models/mediaSource.ts ***!
  \******************************************************************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
eval("__webpack_require__.r(__webpack_exports__);\n/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, \"default\", function() { return MediaSource; });\nclass MediaSource {\r\n    constructor(breakpoint, name, path, url) {\r\n        this.breakpoint = breakpoint;\r\n        this.name = name;\r\n        this.path = path;\r\n        this.url = url;\r\n    }\r\n}\r\n\n\n//# sourceURL=webpack:///./Assets/ResponsiveMedia/js/components/responsiveMediaEditor/models/mediaSource.ts?");

/***/ }),

/***/ "./Assets/ResponsiveMedia/js/components/responsiveMediaEditor/utils/createMediaItem.ts":
/*!*********************************************************************************************!*\
  !*** ./Assets/ResponsiveMedia/js/components/responsiveMediaEditor/utils/createMediaItem.ts ***!
  \*********************************************************************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
eval("__webpack_require__.r(__webpack_exports__);\n/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, \"default\", function() { return createMediaItem; });\n/* harmony import */ var _models_mediaItem__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ../models/mediaItem */ \"./Assets/ResponsiveMedia/js/components/responsiveMediaEditor/models/mediaItem.ts\");\n/* harmony import */ var _sortUtils__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./sortUtils */ \"./Assets/ResponsiveMedia/js/components/responsiveMediaEditor/utils/sortUtils.ts\");\n/* harmony import */ var _getUrlFromSelectedMediaItem__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./getUrlFromSelectedMediaItem */ \"./Assets/ResponsiveMedia/js/components/responsiveMediaEditor/utils/getUrlFromSelectedMediaItem.ts\");\nvar __awaiter = (undefined && undefined.__awaiter) || function (thisArg, _arguments, P, generator) {\r\n    return new (P || (P = Promise))(function (resolve, reject) {\r\n        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }\r\n        function rejected(value) { try { step(generator[\"throw\"](value)); } catch (e) { reject(e); } }\r\n        function step(result) { result.done ? resolve(result.value) : new P(function (resolve) { resolve(result.value); }).then(fulfilled, rejected); }\r\n        step((generator = generator.apply(thisArg, _arguments || [])).next());\r\n    });\r\n};\r\n\r\n\r\n\r\nfunction createMediaItem(breakpoints, selectedMedia) {\r\n    return __awaiter(this, void 0, void 0, function* () {\r\n        const orderedBreakpoints = Object(_sortUtils__WEBPACK_IMPORTED_MODULE_1__[\"sortNumbers\"])(breakpoints).reverse();\r\n        let mediaItem = new _models_mediaItem__WEBPACK_IMPORTED_MODULE_0__[\"default\"]([]);\r\n        return new Promise(resolve => {\r\n            let processedCount = 0;\r\n            const processNextImage = () => {\r\n                const selectedMediaItem = selectedMedia[processedCount];\r\n                const imageUrl = Object(_getUrlFromSelectedMediaItem__WEBPACK_IMPORTED_MODULE_2__[\"default\"])(selectedMediaItem);\r\n                if (imageUrl == null) {\r\n                    processNextImage();\r\n                    return;\r\n                }\r\n                var img = new Image();\r\n                img.onload = function () {\r\n                    const imageWidth = this.naturalWidth;\r\n                    let possibleBreakpoints = [];\r\n                    for (var i = 0; i < orderedBreakpoints.length; i++) {\r\n                        if (orderedBreakpoints[i] <= imageWidth &&\r\n                            !mediaItem.hasSource(orderedBreakpoints[i])) {\r\n                            possibleBreakpoints.push(orderedBreakpoints[i]);\r\n                        }\r\n                    }\r\n                    if (possibleBreakpoints.length > 0) {\r\n                        mediaItem.addSource(Math.max(...possibleBreakpoints), selectedMediaItem);\r\n                    }\r\n                    else {\r\n                        mediaItem.addSource(0, selectedMediaItem);\r\n                    }\r\n                    processedCount++;\r\n                    if (processedCount === selectedMedia.length) {\r\n                        resolve(mediaItem);\r\n                        return;\r\n                    }\r\n                    processNextImage();\r\n                };\r\n                img.src = imageUrl;\r\n            };\r\n            processNextImage();\r\n        });\r\n    });\r\n}\r\n\n\n//# sourceURL=webpack:///./Assets/ResponsiveMedia/js/components/responsiveMediaEditor/utils/createMediaItem.ts?");

/***/ }),

/***/ "./Assets/ResponsiveMedia/js/components/responsiveMediaEditor/utils/getUrlFromSelectedMediaItem.ts":
/*!*********************************************************************************************************!*\
  !*** ./Assets/ResponsiveMedia/js/components/responsiveMediaEditor/utils/getUrlFromSelectedMediaItem.ts ***!
  \*********************************************************************************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
eval("__webpack_require__.r(__webpack_exports__);\n/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, \"default\", function() { return getUrlFromSelectedMedia; });\nfunction isRelative(url) {\r\n    return url.indexOf('http') === -1;\r\n}\r\nfunction getUrlFromSelectedMedia(selectedMediaItem) {\r\n    if (selectedMediaItem == null || selectedMediaItem.url == null) {\r\n        return undefined;\r\n    }\r\n    if (isRelative(selectedMediaItem.url)) {\r\n        return `${window.location.origin}${selectedMediaItem.url}`;\r\n    }\r\n    return selectedMediaItem.url;\r\n}\r\n;\r\n\n\n//# sourceURL=webpack:///./Assets/ResponsiveMedia/js/components/responsiveMediaEditor/utils/getUrlFromSelectedMediaItem.ts?");

/***/ }),

/***/ "./Assets/ResponsiveMedia/js/components/responsiveMediaEditor/utils/parseFieldValue.ts":
/*!*********************************************************************************************!*\
  !*** ./Assets/ResponsiveMedia/js/components/responsiveMediaEditor/utils/parseFieldValue.ts ***!
  \*********************************************************************************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
eval("__webpack_require__.r(__webpack_exports__);\n/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, \"default\", function() { return parseFieldValue; });\n/* harmony import */ var _models_mediaItem__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ../models/mediaItem */ \"./Assets/ResponsiveMedia/js/components/responsiveMediaEditor/models/mediaItem.ts\");\n/* harmony import */ var _models_mediaSource__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../models/mediaSource */ \"./Assets/ResponsiveMedia/js/components/responsiveMediaEditor/models/mediaSource.ts\");\n\r\n\r\nfunction parseFieldValue(initialData) {\r\n    if (!initialData) {\r\n        return [];\r\n    }\r\n    return initialData.map((i) => new _models_mediaItem__WEBPACK_IMPORTED_MODULE_0__[\"default\"](i.sources.map((x) => new _models_mediaSource__WEBPACK_IMPORTED_MODULE_1__[\"default\"](x.breakpoint, x.name, x.path, x.url))));\r\n}\r\n\n\n//# sourceURL=webpack:///./Assets/ResponsiveMedia/js/components/responsiveMediaEditor/utils/parseFieldValue.ts?");

/***/ }),

/***/ "./Assets/ResponsiveMedia/js/components/responsiveMediaEditor/utils/sortUtils.ts":
/*!***************************************************************************************!*\
  !*** ./Assets/ResponsiveMedia/js/components/responsiveMediaEditor/utils/sortUtils.ts ***!
  \***************************************************************************************/
/*! exports provided: sortNumbers */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
eval("__webpack_require__.r(__webpack_exports__);\n/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, \"sortNumbers\", function() { return sortNumbers; });\nconst sortNumbers = (values) => {\r\n    return values.sort((a, b) => {\r\n        return a - b;\r\n    });\r\n};\r\n\n\n//# sourceURL=webpack:///./Assets/ResponsiveMedia/js/components/responsiveMediaEditor/utils/sortUtils.ts?");

/***/ }),

/***/ "./Assets/ResponsiveMedia/js/index.ts":
/*!********************************************!*\
  !*** ./Assets/ResponsiveMedia/js/index.ts ***!
  \********************************************/
/*! no exports provided */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
eval("__webpack_require__.r(__webpack_exports__);\n/* harmony import */ var _components_responsiveMediaEditor__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./components/responsiveMediaEditor */ \"./Assets/ResponsiveMedia/js/components/responsiveMediaEditor/index.ts\");\n\r\nwindow.mediaApp = window.mediaApp || {};\r\nwindow.initializeResponsiveMediaEditor = (el, modalBodyElement, breakpoints, isMultiple) => {\r\n    const rawDataInputElement = document.getElementById($(el).data('for'));\r\n    if (!rawDataInputElement) {\r\n        return;\r\n    }\r\n    Object(_components_responsiveMediaEditor__WEBPACK_IMPORTED_MODULE_0__[\"default\"])(el, $(rawDataInputElement).data('init'), modalBodyElement, breakpoints.sort((a, b) => {\r\n        return a - b;\r\n    }), isMultiple);\r\n};\r\n\n\n//# sourceURL=webpack:///./Assets/ResponsiveMedia/js/index.ts?");

/***/ }),

/***/ "bootstrap":
/*!****************************!*\
  !*** external "bootstrap" ***!
  \****************************/
/*! no static exports found */
/***/ (function(module, exports) {

eval("module.exports = bootstrap;\n\n//# sourceURL=webpack:///external_%22bootstrap%22?");

/***/ }),

/***/ "jquery":
/*!*************************!*\
  !*** external "jQuery" ***!
  \*************************/
/*! no static exports found */
/***/ (function(module, exports) {

eval("module.exports = jQuery;\n\n//# sourceURL=webpack:///external_%22jQuery%22?");

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