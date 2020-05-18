echo -n "Enter a project ID: "
read projectId

echo -n "Enter a project name: "
read projectName

echo -n "Enter a billing account id: "
read billingAccountId

echo "Creating GCP Project"
gcloud projects create $projectId --name="${projectName}" --labels=app=$projectId

echo "Linking project to trial billing account"
gcloud beta billing projects link $projectId --billing-account=$billingAccountId

echo "Switching to created project"
gcloud config set project $projectId

echo "Enabling Kubernetes"
gcloud services enable container.googleapis.com --project=$projectId

echo "Enabling Cloud build"
gcloud services enable cloudbuild.googleapis.com --project=$projectId
