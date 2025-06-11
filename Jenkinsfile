pipeline {
    agent any

    stages {
        stage('Checkout') {
            steps {
                checkout scm
            }
        }

        stage('Build Docker Image') {
            steps {
                dir('MusicRadio.BackEnd.WebApi') {
                    script {
                        sh 'docker build -t musicradio-backend:latest .'
                    }
                }
            }
        }

        stage('Stop & Remove Existing Container') {
            steps {
                script {
                    sh 'docker rm -f musicradio-container || true'
                }
            }
        }

        stage('Run Docker Container') {
            steps {
                script {
                    sh 'docker run -d -p 8081:8080 --name musicradio-container musicradio-backend:latest'
                }
            }
        }
    }
}
