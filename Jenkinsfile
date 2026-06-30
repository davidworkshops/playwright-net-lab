pipeline {
    agent any

    environment {
        DOTNET_CLI_TELEMETRY_OPTOUT = '1'
        DOTNET_NOLOGO = '1'
    }

    stages {
        stage('Checkout') {
            steps {
                checkout scm
            }
        }

        stage('Restore') {
            steps {
                sh 'dotnet restore'
            }
        }

        stage('Build') {
            steps {
                sh 'dotnet build --configuration Release --no-restore'
            }
        }

        stage('Install Playwright Browsers') {
            steps {
                sh '''
                    dotnet test --configuration Release --no-build --list-tests || true
                    pwsh ./bin/Release/net8.0/playwright.ps1 install --with-deps
                '''
            }
        }

        stage('Run E2E Tests') {
            steps {
                sh '''
                    dotnet test \
                      --configuration Release \
                      --no-build \
                      --logger "trx;LogFileName=e2e-tests.trx" \
                      --results-directory TestResults
                '''
            }
        }
    }

    post {
        always {
            archiveArtifacts artifacts: 'TestResults/**/*', allowEmptyArchive: true
        }
    }
}