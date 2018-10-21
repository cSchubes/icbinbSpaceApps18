import torch


def feed_model(image_data):
    
    PATH = '../CNN' ### THIS NEEDS TO BE CHANGED
    
    model = TheModelClass()
    model.load_state_dict(torch.load(PATH))

    model.eval()

    torch_data = torch.from_numpy(image_data)
    
    output = model(torch_data)
    indices = [i for i, n in enumerate(output) if n == 0] # List comprehension

    damaged_pics = [torch_data[i] for i in indices]    

    return damaged_pics