﻿ /*
 * FCKeditor - The text editor for internet
 * Copyright (C) 2003-2005 Frederico Caldeira Knabben
 * 
 * Licensed under the terms of the GNU Lesser General Public License:
 * 		http://www.opensource.org/licenses/lgpl-license.php
 * 
 * For further information visit:
 * 		http://www.fckeditor.net/
 * 
 * File Name: en-au.js
 * 	English (Australia) language file.
 * 
 * File Authors:
 * 		Frederico Caldeira Knabben (fredck@fckeditor.net)
 * 		Christopher Dawes (fckeditor@dawes.id.au)
 */

var FCKLang =
{
// Language direction : "ltr" (left to right) or "rtl" (right to left).
Dir					: "ltr",

ToolbarCollapse		: "Collapse Toolbar",
ToolbarExpand		: "Expand Toolbar",

// Toolbar Items and Context Menu
Save				: "Save",
NewPage				: "New Page",
Preview				: "Preview",
Cut					: "Cut",
Copy				: "Copy",
Paste				: "Paste",
PasteText			: "Paste as plain text",
PasteWord			: "Paste from Word",
Print				: "Print",
SelectAll			: "Select All",
RemoveFormat		: "Remove Format",
InsertLinkLbl		: "Link",
InsertLink			: "Insert/Edit Link",
RemoveLink			: "Remove Link",
Anchor				: "Insert/Edit Anchor",
InsertImageLbl		: "Image",
InsertImage			: "Insert/Edit Image",
InsertFlashLbl		: "Flash",
InsertFlash			: "Insert/Edit Flash",
InsertTableLbl		: "Table",
InsertTable			: "Insert/Edit Table",
InsertLineLbl		: "Line",
InsertLine			: "Insert Horizontal Line",
InsertSpecialCharLbl: "Special Char",
InsertSpecialChar	: "Insert Special Character",
InsertSmileyLbl		: "Smiley",
InsertSmiley		: "Insert Smiley",
About				: "About FCKeditor",
Bold				: "Bold",
Italic				: "Italic",
Underline			: "Underline",
StrikeThrough		: "Strike Through",
Subscript			: "Subscript",
Superscript			: "Superscript",
LeftJustify			: "Left Justify",
CenterJustify		: "Center Justify",
RightJustify		: "Right Justify",
BlockJustify		: "Block Justify",
DecreaseIndent		: "Decrease Indent",
IncreaseIndent		: "Increase Indent",
Undo				: "Undo",
Redo				: "Redo",
NumberedListLbl		: "Numbered List",
NumberedList		: "Insert/Remove Numbered List",
BulletedListLbl		: "Bulleted List",
BulletedList		: "Insert/Remove Bulleted List",
ShowTableBorders	: "Show Table Borders",
ShowDetails			: "Show Details",
Style				: "Style",
FontFormat			: "Format",
Font				: "Font",
FontSize			: "Size",
TextColor			: "Text Color",
BGColor				: "Background Color",
Source				: "Source",
Find				: "Find",
Replace				: "Replace",
SpellCheck			: "Check Spell",
UniversalKeyboard	: "Universal Keyboard",

Form			: "Form",
Checkbox		: "Checkbox",
RadioButton		: "Radio Button",
TextField		: "TextField",
Textarea		: "Textarea",
HiddenField		: "Hidden Field",
Button			: "Button",
SelectionField	: "Selection Field",
ImageButton		: "Image Button",

// Context Menu
EditLink			: "Edit Link",
InsertRow			: "Insert Row",
DeleteRows			: "Delete Rows",
InsertColumn		: "Insert Column",
DeleteColumns		: "Delete Columns",
InsertCell			: "Insert Cell",
DeleteCells			: "Delete Cells",
MergeCells			: "Merge Cells",
SplitCell			: "Split Cell",
CellProperties		: "Cell Properties",
TableProperties		: "Table Properties",
ImageProperties		: "Image Properties",
FlashProperties		: "Flash Properties",

AnchorProp			: "Anchor Properties",
ButtonProp			: "Button Properties",
CheckboxProp		: "Checkbox Properties",
HiddenFieldProp		: "Hidden Field Properties",
RadioButtonProp		: "Radio Button Properties",
ImageButtonProp		: "Image Button Properties",
TextFieldProp		: "TextField Properties",
SelectionFieldProp	: "Selection Field Properties",
TextareaProp		: "Textarea Properties",
FormProp			: "Form Properties",

FontFormats			: "Normal;Formatted;Address;Heading 1;Heading 2;Heading 3;Heading 4;Heading 5;Heading 6;Paragraph (DIV)",

// Alerts and Messages
ProcessingXHTML		: "Processing XHTML. Please wait...",
Done				: "Done",
PasteWordConfirm	: "The text you want to paste seems to be copied from Word. Do you want to clean it before pasting?",
NotCompatiblePaste	: "This command is available for Internet Explorer version 5.5 or more. Do you want to paste without cleaning?",
UnknownToolbarItem	: "Unknown toolbar item \"%1\"",
UnknownCommand		: "Unknown command name \"%1\"",
NotImplemented		: "Command not implemented",
UnknownToolbarSet	: "Toolbar set \"%1\" doesn't exist",

// Dialogs
DlgBtnOK			: "OK",
DlgBtnCancel		: "Cancel",
DlgBtnClose			: "Close",
DlgBtnBrowseServer	: "Browse Server",
DlgAdvancedTag		: "Advanced",
DlgOpOther			: "&lt;Other&gt;",
DlgInfoTab			: "Info",
DlgAlertUrl			: "Please insert the URL",

// General Dialogs Labels
DlgGenNotSet		: "&lt;not set&gt;",
DlgGenId			: "Id",
DlgGenLangDir		: "Language Direction",
DlgGenLangDirLtr	: "Left to Right (LTR)",
DlgGenLangDirRtl	: "Right to Left (RTL)",
DlgGenLangCode		: "Language Code",
DlgGenAccessKey		: "Access Key",
DlgGenName			: "Name",
DlgGenTabIndex		: "Tab Index",
DlgGenLongDescr		: "Long Description URL",
DlgGenClass			: "Stylesheet Classes",
DlgGenTitle			: "Advisory Title",
DlgGenContType		: "Advisory Content Type",
DlgGenLinkCharset	: "Linked Resource Charset",
DlgGenStyle			: "Style",

// Image Dialog
DlgImgTitle			: "Image Properties",
DlgImgInfoTab		: "Image Info",
DlgImgBtnUpload		: "Send it to the Server",
DlgImgURL			: "URL",
DlgImgUpload		: "Upload",
DlgImgAlt			: "Alternative Text",
DlgImgWidth			: "Width",
DlgImgHeight		: "Height",
DlgImgLockRatio		: "Lock Ratio",
DlgBtnResetSize		: "Reset Size",
DlgImgBorder		: "Border",
DlgImgHSpace		: "HSpace",
DlgImgVSpace		: "VSpace",
DlgImgAlign			: "Align",
DlgImgAlignLeft		: "Left",
DlgImgAlignAbsBottom: "Abs Bottom",
DlgImgAlignAbsMiddle: "Abs Middle",
DlgImgAlignBaseline	: "Baseline",
DlgImgAlignBottom	: "Bottom",
DlgImgAlignMiddle	: "Middle",
DlgImgAlignRight	: "Right",
DlgImgAlignTextTop	: "Text Top",
DlgImgAlignTop		: "Top",
DlgImgPreview		: "Preview",
DlgImgAlertUrl		: "Please type the image URL",
DlgImgLinkTab		: "Link",

// Flash Dialog
DlgFlashTitle		: "Flash Properties",
DlgFlashChkPlay		: "Auto Play",
DlgFlashChkLoop		: "Loop",
DlgFlashChkMenu		: "Enable Flash Menu",
DlgFlashScale		: "Scale",
DlgFlashScaleAll	: "Show all",
DlgFlashScaleNoBorder	: "No Border",
DlgFlashScaleFit	: "Exact Fit",

// Link Dialog
DlgLnkWindowTitle	: "Link",
DlgLnkInfoTab		: "Link Info",
DlgLnkTargetTab		: "Target",

DlgLnkType			: "Link Type",
DlgLnkTypeURL		: "URL",
DlgLnkTypeAnchor	: "Anchor in this page",
DlgLnkTypeEMail		: "E-Mail",
DlgLnkProto			: "Protocol",
DlgLnkProtoOther	: "&lt;other&gt;",
DlgLnkURL			: "URL",
DlgLnkAnchorSel		: "Select an Anchor",
DlgLnkAnchorByName	: "By Anchor Name",
DlgLnkAnchorById	: "By Element Id",
DlgLnkNoAnchors		: "&lt;No anchors available in the document&gt;",
DlgLnkEMail			: "E-Mail Address",
DlgLnkEMailSubject	: "Message Subject",
DlgLnkEMailBody		: "Message Body",
DlgLnkUpload		: "Upload",
DlgLnkBtnUpload		: "Send it to the Server",

DlgLnkTarget		: "Target",
DlgLnkTargetFrame	: "&lt;frame&gt;",
DlgLnkTargetPopup	: "&lt;popup window&gt;",
DlgLnkTargetBlank	: "New Window (_blank)",
DlgLnkTargetParent	: "Parent Window (_parent)",
DlgLnkTargetSelf	: "Same Window (_self)",
DlgLnkTargetTop		: "Topmost Window (_top)",
DlgLnkTargetFrameName	: "Target Frame Name",
DlgLnkPopWinName	: "Popup Window Name",
DlgLnkPopWinFeat	: "Popup Window Features",
DlgLnkPopResize		: "Resizable",
DlgLnkPopLocation	: "Location Bar",
DlgLnkPopMenu		: "Menu Bar",
DlgLnkPopScroll		: "Scroll Bars",
DlgLnkPopStatus		: "Status Bar",
DlgLnkPopToolbar	: "Toolbar",
DlgLnkPopFullScrn	: "Full Screen (IE)",
DlgLnkPopDependent	: "Dependent (Netscape)",
DlgLnkPopWidth		: "Width",
DlgLnkPopHeight		: "Height",
DlgLnkPopLeft		: "Left Position",
DlgLnkPopTop		: "Top Position",

DlnLnkMsgNoUrl		: "Please type the link URL",
DlnLnkMsgNoEMail	: "Please type the e-mail address",
DlnLnkMsgNoAnchor	: "Please select an anchor",

// Color Dialog
DlgColorTitle		: "Select Color",
DlgColorBtnClear	: "Clear",
DlgColorHighlight	: "Highlight",
DlgColorSelected	: "Selected",

// Smiley Dialog
DlgSmileyTitle		: "Insert a Smiley",

// Special Character Dialog
DlgSpecialCharTitle	: "Select Special Character",

// Table Dialog
DlgTableTitle		: "Table Properties",
DlgTableRows		: "Rows",
DlgTableColumns		: "Columns",
DlgTableBorder		: "Border size",
DlgTableAlign		: "Alignment",
DlgTableAlignNotSet	: "<Not set>",
DlgTableAlignLeft	: "Left",
DlgTableAlignCenter	: "Centre",
DlgTableAlignRight	: "Right",
DlgTableWidth		: "Width",
DlgTableWidthPx		: "pixels",
DlgTableWidthPc		: "percent",
DlgTableHeight		: "Height",
DlgTableCellSpace	: "Cell spacing",
DlgTableCellPad		: "Cell padding",
DlgTableCaption		: "Caption",

// Table Cell Dialog
DlgCellTitle		: "Cell Properties",
DlgCellWidth		: "Width",
DlgCellWidthPx		: "pixels",
DlgCellWidthPc		: "percent",
DlgCellHeight		: "Height",
DlgCellWordWrap		: "Word Wrap",
DlgCellWordWrapNotSet	: "&lt;Not set&gt;",
DlgCellWordWrapYes	: "Yes",
DlgCellWordWrapNo	: "No",
DlgCellHorAlign		: "Horizontal Alignment",
DlgCellHorAlignNotSet	: "&lt;Not set&gt;",
DlgCellHorAlignLeft	: "Left",
DlgCellHorAlignCenter	: "Centre",
DlgCellHorAlignRight: "Right",
DlgCellVerAlign		: "Vertical Alignment",
DlgCellVerAlignNotSet	: "&lt;Not set&gt;",
DlgCellVerAlignTop	: "Top",
DlgCellVerAlignMiddle	: "Middle",
DlgCellVerAlignBottom	: "Bottom",
DlgCellVerAlignBaseline	: "Baseline",
DlgCellRowSpan		: "Rows Span",
DlgCellCollSpan		: "Columns Span",
DlgCellBackColor	: "Background Color",
DlgCellBorderColor	: "Border Color",
DlgCellBtnSelect	: "Select...",

// Find Dialog
DlgFindTitle		: "Find",
DlgFindFindBtn		: "Find",
DlgFindNotFoundMsg	: "The specified text was not found.",

// Replace Dialog
DlgReplaceTitle			: "Replace",
DlgReplaceFindLbl		: "Find what:",
DlgReplaceReplaceLbl	: "Replace with:",
DlgReplaceCaseChk		: "Match case",
DlgReplaceReplaceBtn	: "Replace",
DlgReplaceReplAllBtn	: "Replace All",
DlgReplaceWordChk		: "Match whole word",

// Paste Operations / Dialog
PasteErrorPaste	: "Your browser security settings don't permit the editor to automaticaly execute pasting operations. Please use the keyboard for that (Ctrl+V).",
PasteErrorCut	: "Your browser security settings don't permit the editor to automaticaly execute cutting operations. Please use the keyboard for that (Ctrl+X).",
PasteErrorCopy	: "Your browser security settings don't permit the editor to automaticaly execute copying operations. Please use the keyboard for that (Ctrl+C).",

PasteAsText		: "Paste as Plain Text",
PasteFromWord	: "Paste from Word",

DlgPasteMsg2	: "Please paste inside the following box using the keyboard (<STRONG>Ctrl+V</STRONG>) and hit <STRONG>OK</STRONG>.",
DlgPasteIgnoreFont		: "Ignore Font Face definitions",
DlgPasteRemoveStyles	: "Remove Styles definitions",
DlgPasteCleanBox		: "Clean Up Box",


// Color Picker
ColorAutomatic	: "Automatic",
ColorMoreColors	: "More Colors...",

// Document Properties
DocProps		: "Document Properties",

// Anchor Dialog
DlgAnchorTitle		: "Anchor Properties",
DlgAnchorName		: "Anchor Name",
DlgAnchorErrorName	: "Please type the anchor name",

// Speller Pages Dialog
DlgSpellNotInDic		: "Not in dictionary",
DlgSpellChangeTo		: "Change to",
DlgSpellBtnIgnore		: "Ignore",
DlgSpellBtnIgnoreAll	: "Ignore All",
DlgSpellBtnReplace		: "Replace",
DlgSpellBtnReplaceAll	: "Replace All",
DlgSpellBtnUndo			: "Undo",
DlgSpellNoSuggestions	: "- No suggestions -",
DlgSpellProgress		: "Spell check in progress...",
DlgSpellNoMispell		: "Spell check complete: No misspellings found",
DlgSpellNoChanges		: "Spell check complete: No words changed",
DlgSpellOneChange		: "Spell check complete: One word changed",
DlgSpellManyChanges		: "Spell check complete: %1 words changed",

IeSpellDownload			: "Spell checker not installed. Do you want to download it now?",

// Button Dialog
DlgButtonText	: "Text (Value)",
DlgButtonType	: "Type",

// Checkbox and Radio Button Dialogs
DlgCheckboxName		: "Name",
DlgCheckboxValue	: "Value",
DlgCheckboxSelected	: "Selected",

// Form Dialog
DlgFormName		: "Name",
DlgFormAction	: "Action",
DlgFormMethod	: "Method",

// Select Field Dialog
DlgSelectName		: "Name",
DlgSelectValue		: "Value",
DlgSelectSize		: "Size",
DlgSelectLines		: "lines",
DlgSelectChkMulti	: "Allow multiple selections",
DlgSelectOpAvail	: "Available Options",
DlgSelectOpText		: "Text",
DlgSelectOpValue	: "Value",
DlgSelectBtnAdd		: "Add",
DlgSelectBtnModify	: "Modify",
DlgSelectBtnUp		: "Up",
DlgSelectBtnDown	: "Down",
DlgSelectBtnSetValue : "Set as selected value",
DlgSelectBtnDelete	: "Delete",

// Textarea Dialog
DlgTextareaName	: "Name",
DlgTextareaCols	: "Columns",
DlgTextareaRows	: "Rows",

// TextField Dialog
DlgTextName			: "Name",
DlgTextValue		: "Value",
DlgTextCharWidth	: "Character Width",
DlgTextMaxChars		: "Maximum Characters",
DlgTextType			: "Type",
DlgTextTypeText		: "Text",
DlgTextTypePass		: "Password",

// Hidden Field Dialog
DlgHiddenName	: "Name",
DlgHiddenValue	: "Value",

// Bulleted List Dialog
BulletedListProp	: "Bulleted List Properties",
NumberedListProp	: "Numbered List Properties",
DlgLstType			: "Type",
DlgLstTypeCircle	: "Circle",
DlgLstTypeDisk		: "Disk",
DlgLstTypeSquare	: "Square",
DlgLstTypeNumbers	: "Numbers (1, 2, 3)",
DlgLstTypeLCase		: "Lowercase Letters (a, b, c)",
DlgLstTypeUCase		: "Uppercase Letters (A, B, C)",
DlgLstTypeSRoman	: "Small Roman Numerals (i, ii, iii)",
DlgLstTypeLRoman	: "Large Roman Numerals (I, II, III)",

// Document Properties Dialog
DlgDocGeneralTab	: "General",
DlgDocBackTab		: "Background",
DlgDocColorsTab		: "Colors and Margins",
DlgDocMetaTab		: "Meta Data",

DlgDocPageTitle		: "Page Title",
DlgDocLangDir		: "Language Direction",
DlgDocLangDirLTR	: "Left to Right (LTR)",
DlgDocLangDirRTL	: "Right to Left (RTL)",
DlgDocLangCode		: "Language Code",
DlgDocCharSet		: "Character Set Encoding",
DlgDocCharSetOther	: "Other Character Set Encoding",

DlgDocDocType		: "Document Type Heading",
DlgDocDocTypeOther	: "Other Document Type Heading",
DlgDocIncXHTML		: "Include XHTML Declarations",
DlgDocBgColor		: "Background Color",
DlgDocBgImage		: "Background Image URL",
DlgDocBgNoScroll	: "Nonscrolling Background",
DlgDocCText			: "Text",
DlgDocCLink			: "Link",
DlgDocCVisited		: "Visited Link",
DlgDocCActive		: "Active Link",
DlgDocMargins		: "Page Margins",
DlgDocMaTop			: "Top",
DlgDocMaLeft		: "Left",
DlgDocMaRight		: "Right",
DlgDocMaBottom		: "Bottom",
DlgDocMeIndex		: "Document Indexing Keywords (comma separated)",
DlgDocMeDescr		: "Document Description",
DlgDocMeAuthor		: "Author",
DlgDocMeCopy		: "Copyright",
DlgDocPreview		: "Preview",

// Templates Dialog
Templates			: "Templates",
DlgTemplatesTitle	: "Content Templates",
DlgTemplatesSelMsg	: "Please select the template to open in the editor<br>(the actual contents will be lost):",
DlgTemplatesLoading	: "Loading templates list. Please wait...",
DlgTemplatesNoTpl	: "(No templates defined)",

// About Dialog
DlgAboutAboutTab	: "About",
DlgAboutBrowserInfoTab	: "Browser Info",
DlgAboutVersion		: "version",
DlgAboutLicense		: "Licensed under the terms of the GNU Lesser General Public License",
DlgAboutInfo		: "For further information go to"
}