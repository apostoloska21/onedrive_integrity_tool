# Investigating File Integrity in Microsoft OneDrive Using the Graph API
## Purpose : Prove whether OneDrive keeps files 100% identical when you upload and then download them using Microsoft Graph API.
## Overview
This project implements a file integrity verification tool for Microsoft OneDrive using the Microsoft Graph API. The tool uploads files to OneDrive, downloads them back, and performs SHA-256 hash comparison to verify that files maintain their integrity during cloud storage operations.

## Research Question
Does OneDrive preserve the integrity of files during upload and download operations?

## Hypothesis
Files uploaded to OneDrive and then downloaded will remain bit-for-bit identical, meaning their SHA-256 cryptographic hashes should match perfectly. Any discrepancies may reveal issues related to file encoding, API handling, or metadata modifications.

## Architecture
The solution follows object-oriented principles with clear separation of concerns:

## Core Components
AuthManager.cs - Handles Microsoft graph API authentication using client credentials flow

FileUploader.cs - Manages file upload operations to OneDrive

FileDownloader.cs - Handles file download operations from OneDrive

CalculatorSHA.cs - Computes sha-256 cryptographic hashes for integrity verification

Program.cs - Main application logick coordinating the upload-download workflow

## Data Flow

Local File → sha-256 hash → upload to OneDrive → download from OneDrive → sha-256 hash → compare hashes

## Prerequisites
Microsoft 365 work/school account with OneDrive for Business


## Azure AD App Registration with:

Application (client) ID

Directory (tenant) ID

Client secret

## API Permissions in Azure: 

Files.Read.All (Application permission)

Files.ReadWrite.All (Application permission)

Admin consent granted for all permissions

Microsoft 365 License with OneDrive for Business/SharePoint Online