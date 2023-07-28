/**
 * @license Copyright (c) 2003-2023, CKSource Holding sp. z o.o. All rights reserved.
 * For licensing, see https://ckeditor.com/legal/ckeditor-oss-license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	config.language = 'vi';
	config.uiColor = '#AADC6E';
	config.extraPlugins = 'syntaxhighlight';
	config.syntaxhighlight_lang = 'csharp';
	config.syntaxhighlight_hideControls = true;
	config.filebrowserBrowseUrl = '/Asests/Admin/js/plugins/ckfinder/ckfinder.html';
	config.filebrowserImageBrowseUrl = '/Asests/Admin/js/plugins/ckfinder/ckfinder.html?Type=Images';
	config.filebrowserUpdateUrl = '/Asests/Admin/js/plugins/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files';
	config.filebrowserImageUploadUrl = '/Data';
	config.filebrowserFlashBrowseUrl = '/Asests/Admin/js/plugins/ckfinder/ckfinder.html?Type=Flash';
	config.filebrowserFlashUploadUrl = '/Asests/Admin/js/plugins/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash';
};
