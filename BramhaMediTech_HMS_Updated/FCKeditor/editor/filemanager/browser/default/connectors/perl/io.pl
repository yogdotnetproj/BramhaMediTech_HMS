 #####
#  FCKeditor - The text editor for internet
#  Copyright (C) 2003-2005 Frederico Caldeira Knabben
#  
#  Licensed under the terms of the GNU Lesser General Public License:
#  		http://www.opensource.org/licenses/lgpl-license.php
#  
#  For further information visit:
#  		http://www.fckeditor.net/
#  
#  File Name: io.pl
#  	This is the File Manager Connector for Perl.
#  
#  File Authors:
#  		Takashi Yamaguchi (jack@omakase.net)
#####

sub GetUrlFromPath
{
	local($resourceType, $folderPath) = @_;

	if($resourceType eq '') {
		$rmpath = &RemoveFromEnd($GLOBALS{'UserFilesPath'},'/');
		return("$rmpath$folderPath");
	} else {
		return("$GLOBALS{'UserFilesPath'}$resourceType$folderPath");
	}
}

sub RemoveExtension
{
	local($fileName) = @_;
	local($path, $base, $ext);
	if($fileName !~ /\./) {
		$fileName .= '.';
	}
	if($fileName =~ /([^\\\/]*)\.(.*)$/) {
		$base = $1;
		$ext  = $2;
		if($fileName =~ /(.*)$base\.$ext$/) {
			$path = $1;
		}
	}
	return($path,$base,$ext);

}

sub ServerMapFolder
{
	local($resourceType,$folderPath) = @_;

	# Get the resource type directory.
	$sResourceTypePath = $GLOBALS{'UserFilesDirectory'} . $resourceType . '/';

	# Ensure that the directory exists.
	&CreateServerFolder($sResourceTypePath);

	# Return the resource type directory combined with the required path.
	$rmpath = &RemoveFromStart($folderPath,'/');
	return("$sResourceTypePath$rmpath");
}

sub GetParentFolder
{
	local($folderPath) = @_;

	$folderPath =~ s/[\/][^\/]+[\/]?$//g;
	return $folderPath;
}

sub CreateServerFolder
{
	local($folderPath) = @_;

	$sParent = &GetParentFolder($folderPath);
	# Check if the parent exists, or create it.
	if(!(-e $sParent)) {
		$sErrorMsg = &CreateServerFolder($sParent);
		if($sErrorMsg == 1) {
			return(1);
		}
	}
	if(!(-e $folderPath)) {
		umask(000);
		mkdir("$folderPath",0777);
		chmod(0777,"$folderPath");
		return(0);
	} else {
		return(1);
	}
}

sub GetRootPath
{
#use Cwd;

#	my $dir = getcwd;
#	print $dir;
#	$dir  =~ s/$ENV{'DOCUMENT_ROOT'}//g;
#	print $dir;
#	return($dir);

#	$wk = $0;
#	$wk =~ s/\/connector\.cgi//g;
#	if($wk) {
#		$current_dir = $wk;
#	} else {
#		$current_dir = `pwd`;
#	}
#	return($current_dir);
use Cwd;

	if($ENV{'DOCUMENT_ROOT'}) {
		$dir = $ENV{'DOCUMENT_ROOT'};
	} else {
		my $dir = getcwd;
		$workdir =~ s/\/connector\.cgi//g;
		$dir  =~ s/$workdir//g;
	}
	return($dir);



}
1;
