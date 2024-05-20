import os
from pdfmerge import pdfmerge

output_file = "output.pdf"
dest_dir = os.getcwd() + "\\python\\pdf-merger-output"
output_path = os.path.join(dest_dir, output_file)

pdfmerge(["path.pdf", "path.pdf", "path.pdf"], output_path)