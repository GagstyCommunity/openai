import SwiftUI

struct ContentView: View {
    @State private var showImagePicker = false
    @State private var image: UIImage?
    @State private var isLoading = false
    @State private var modelURL: URL?

    var body: some View {
        VStack {
            if let image = image {
                Image(uiImage: image)
                    .resizable()
                    .scaledToFit()
            } else {
                Text("Select a photo")
            }

            Button(action: { showImagePicker = true }) {
                Text("Choose Photo")
            }
            .padding()

            if isLoading {
                ProgressView()
            }

            if let url = modelURL {
                Text("3D Model: \(url.lastPathComponent)")
            }
        }
        .sheet(isPresented: $showImagePicker) {
            ImagePicker(image: $image, onComplete: upload)
        }
    }

    func upload() {
        guard let _ = image else { return }
        isLoading = true
        // TODO: implement network upload to backend
        isLoading = false
    }
}

struct ContentView_Previews: PreviewProvider {
    static var previews: some View {
        ContentView()
    }
}
