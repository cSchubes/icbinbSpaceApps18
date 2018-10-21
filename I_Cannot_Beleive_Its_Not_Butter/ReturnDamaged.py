import torch
from torchvision import datasets, models, transforms
import torch.nn as nn
import numpy as np



## 
def feed_model(image_data):
    device = torch.device("cpu")
    PATH = 'C:/Users/nwest1/Desktop/SpaceApps/Adadelta_CrossEntropyLoss_4_resnet34_0.501_0.434ptc'
    checkpoint = torch.load(PATH)
    model = models.resnet34(pretrained=True)
    num_features = model.fc.in_features
    model.fc = nn.Linear(num_features, 2)
    model = model.to(device)
    model.load_state_dict(checkpoint['model'])
    
    model.eval()

    inp = np.random.rand(2, 3, 224, 224) ## this is filler
    print(inp)
    '''
    torch_data = torch.from_numpy(image_data)
    
    output = model(torch_data)
    
    indices = [i for i, n in enumerate(output) if n == 0] # List comprehension

    damaged_pics = [torch_data[i] for i in indices]    

    return damaged_pics
    '''


feed_model(4)
