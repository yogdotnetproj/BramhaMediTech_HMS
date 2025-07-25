 <?php 
/*
 * FCKeditor - The text editor for internet
 * Copyright (C) 2003-2005 Frederico Caldeira Knabben
 * 
 * Licensed under the terms of the GNU Lesser General Public License:
 * 		http://www.opensource.org/licenses/lgpl-license.php
 * 
 * For further information visit:
 * 		http://www.fckeditor.net/
 * 
 * File Name: connector.php
 * 	This is the File Manager Connector for PHP.
 * 
 * File Authors:
 * 		Frederico Caldeira Knabben (fredck@fckeditor.net)
 */

include('config.php') ;
include('util.php') ;
include('io.php') ;
include('basexml.php') ;
include('commands.php') ;

if ( !$Config['Enabled'] )
	SendError( 1, 'This connector is disabled. Please check the "editor/filemanager/browser/default/connectors/php/config.php" file' ) ;

// Get the "UserFiles" path.
$GLOBALS["UserFilesPath"] = '' ;

if ( isset( $Config['UserFilesPath'] ) )
	$GLOBALS["UserFilesPath"] = $Config['UserFilesPath'] ;
else if ( isset( $_GET['ServerPath'] ) )
	$GLOBALS["UserFilesPath"] = $_GET['ServerPath'] ;
else
	$GLOBALS["UserFilesPath"] = '/UserFiles/' ;

if ( ! ereg( '/$', $GLOBALS["UserFilesPath"] ) )
	$GLOBALS["UserFilesPath"] .= '/' ;

// Map the "UserFiles" path to a local directory.
//$GLOBALS["UserFilesDirectory"] = GetRootPath() . str_replace( '/', '\\', $GLOBALS["UserFilesPath"] ) ;
$GLOBALS["UserFilesDirectory"] = GetRootPath() . $GLOBALS["UserFilesPath"] ;

DoResponse() ;

function DoResponse()
{
	if ( !isset( $_GET['Command'] ) || !isset( $_GET['Type'] ) || !isset( $_GET['CurrentFolder'] ) )
		return ;

	// Get the main request informaiton.
	$sCommand		= $_GET['Command'] ;
	$sResourceType	= $_GET['Type'] ;
	$sCurrentFolder	= $_GET['CurrentFolder'] ;

	// Check if it is an allowed type.
	if ( !in_array( $sResourceType, array('File','Image','Flash','Media') ) )
		return ;

	// Check the current folder syntax (must begin and start with a slash).
	if ( ! ereg( '/$', $sCurrentFolder ) ) $sCurrentFolder .= '/' ;
	if ( strpos( $sCurrentFolder, '/' ) !== 0 ) $sCurrentFolder = '/' . $sCurrentFolder ;
	
	// Check for invalid folder paths (..)
	if ( strpos( $sCurrentFolder, '..' ) )
		SendError( 102, "" ) ;

	// File Upload doesn't have to Return XML, so it must be intercepted before anything.
	if ( $sCommand == 'FileUpload' )
	{
		FileUpload( $sResourceType, $sCurrentFolder ) ;
		return ;
	}

	CreateXmlHeader( $sCommand, $sResourceType, $sCurrentFolder ) ;

	// Execute the required command.
	switch ( $sCommand )
	{
		case 'GetFolders' :
			GetFolders( $sResourceType, $sCurrentFolder ) ;
			break ;
		case 'GetFoldersAndFiles' :
			GetFoldersAndFiles( $sResourceType, $sCurrentFolder ) ;
			break ;
		case 'CreateFolder' :
			CreateFolder( $sResourceType, $sCurrentFolder ) ;
			break ;
	}

	CreateXmlFooter() ;

	exit ;
}
?>